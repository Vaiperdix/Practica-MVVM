using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainMenuController : IDisposable
{
    private readonly MainMenuViewModel _model;
    private readonly MainMenuRequest _mainMenuRequest;
    private List<IDisposable> _disposables = new List<IDisposable>();

    public MainMenuController(MainMenuViewModel model, MainMenuRequest mainMenuRequest)
    {
        _model = model;
        _mainMenuRequest = mainMenuRequest;

        _model.OptionButtonPressed.Subscribe(OnOptionButtonPressed).AddTo(_disposables);
    }

    private void OnOptionButtonPressed(Unit _)
    {
        _mainMenuRequest.Options();
    }


    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
            Debug.Log("Dispose");
        }
    }
}
