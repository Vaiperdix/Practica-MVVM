using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OptionMenuViewModel
{
    public readonly ReactiveCommand MainMenuButtonPressed;
    public readonly ReactiveCommand changeColorButtonPressed;
    public readonly ReactiveCommand changeSpriteButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveProperty<Color> color;
    public readonly ReactiveProperty<Sprite> sprite;

    public OptionMenuViewModel()
    {
        MainMenuButtonPressed = new ReactiveCommand();
        changeColorButtonPressed = new ReactiveCommand();
        changeSpriteButtonPressed = new ReactiveCommand();

        IsVisible = new BoolReactiveProperty(initialValue: false);
        color = new ColorReactiveProperty(Color.grey);
        sprite = new ReactiveProperty<Sprite>(Resources.Load<Sprite>("Sprite Folder/sprite1"));
    }
}
