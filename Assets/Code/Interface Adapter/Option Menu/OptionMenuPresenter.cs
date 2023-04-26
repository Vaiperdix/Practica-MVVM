using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OptionMenuPresenter : IDisposable
{
    private readonly OptionMenuViewModel _model;

    public OptionMenuPresenter(OptionMenuViewModel model)
    {
        _model = model;

        EventDispatcherService.Instance.Subscribe<WelcomeData>(OnDataUpdated);
        EventDispatcherService.Instance.Subscribe<OptionData>(OnOptionsUpdated);
    }


    private void OnDataUpdated(WelcomeData data)
    {
        _model.IsVisible.Value = !_model.IsVisible.Value;
    }

    private void OnOptionsUpdated(OptionData data)
    {
        _model.color.Value = data.spriteColor;
        _model.sprite.Value = data.spriteName;
    }

    public void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<WelcomeData>(OnDataUpdated);
        Debug.Log("Dispose");
    }
}
