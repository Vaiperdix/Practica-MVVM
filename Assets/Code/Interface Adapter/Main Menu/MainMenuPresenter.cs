using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainMenuPresenter : IDisposable
{
    private readonly MainMenuViewModel _model;

    public MainMenuPresenter(MainMenuViewModel model)
    {
        _model = model;

        EventDispatcherService.Instance.Subscribe<WelcomeData>(OnDataUpdated);
    }

    private void OnDataUpdated(WelcomeData data)
    {
        _model.IsVisible.Value = !_model.IsVisible.Value;
    }

    public void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<WelcomeData>(OnDataUpdated);
        Debug.Log("Dispose");
    }
}
