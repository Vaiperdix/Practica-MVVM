using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OptionMenuController : IDisposable
{
    private readonly OptionMenuViewModel _model;
    private readonly OptionMenuRequest _optionMenuRequest;

    private List<IDisposable> _disposables = new List<IDisposable>();

    public OptionMenuController(OptionMenuViewModel model, OptionMenuRequest optionMenuRequest)
    {
        _model = model;
        _optionMenuRequest = optionMenuRequest;

        _model.MainMenuButtonPressed.Subscribe(OnMainMenuButtonPressed).AddTo(_disposables);

        _model.changeColorButtonPressed.Subscribe(OnChangeColorButtonPressed).AddTo(_disposables);

        _model.changeSpriteButtonPressed.Subscribe(OnChangeSpriteButtonPressed).AddTo(_disposables);
    }

    private void OnChangeSpriteButtonPressed(Unit _)
    {
        _optionMenuRequest.ChangeSprite();
    }

    private void OnChangeColorButtonPressed(Unit _)
    {
        _optionMenuRequest.ChangeColor();
    }

    private void OnMainMenuButtonPressed(Unit _)
    {
        _optionMenuRequest.MainMenu();
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
