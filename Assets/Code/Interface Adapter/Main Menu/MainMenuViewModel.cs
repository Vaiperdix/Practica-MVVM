using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainMenuViewModel
{
    public readonly ReactiveCommand OptionButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;


    public MainMenuViewModel()
    {
        OptionButtonPressed = new ReactiveCommand();
        IsVisible = new BoolReactiveProperty(initialValue: true);
    }
}
