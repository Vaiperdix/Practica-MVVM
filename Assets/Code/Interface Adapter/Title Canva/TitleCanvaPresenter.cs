using System;
using System.Collections.Generic;
using UnityEngine;

public class TitleCanvaPresenter : IDisposable
{
    private readonly TitleCanvaViewModel _model;

    public TitleCanvaPresenter(TitleCanvaViewModel model)
    {
        _model = model;

        EventDispatcherService.Instance.Subscribe<WelcomeData>(OnDataUpdated);

    }

    private void OnDataUpdated(WelcomeData data)
    {
        _model.DataSms.Value = data.welcome;
    }

    public void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<WelcomeData>(OnDataUpdated);
        Debug.Log("Dispose");
    }
}
