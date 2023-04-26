using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MainMenuView : BaseView
{
    private Button _optionMenuButton;

    private MainMenuViewModel _model;


    public override void Configure(MainMenuViewModel model)
    {
        _optionMenuButton = GameObject.Find("Option Menu Button").GetComponent<Button>();

        _model = model;

        _optionMenuButton.onClick.AddListener(OptionButtonPressedCall);

        _model
            .IsVisible
            .Skip(3)
            .Take(3)            
            .Subscribe(onNext: isVisible => IsVisibleCall(isVisible))
            .AddTo(_disposables);
    }

    void IsVisibleCall(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    void OptionButtonPressedCall()
    {
        _model.OptionButtonPressed.Execute();
    }

}
