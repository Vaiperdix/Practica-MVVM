using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class OptionMenuView : BaseView
{
    private Button _mainMenuButton;
    private Button _changeColorButton;
    private Button _changeSpriteButton;
    Image _color;
    Image _image;


    private OptionMenuViewModel _model;

    public override void Configure(OptionMenuViewModel model)
    {
        _mainMenuButton = GameObject.Find("Main Menu Button").GetComponent<Button>();
        _changeColorButton = GameObject.Find("Change Color Button").GetComponent<Button>();
        _changeSpriteButton = GameObject.Find("Change Sprite Button").GetComponent<Button>();
        _color = GameObject.Find("Color").GetComponent<Image>();
        _image = GameObject.Find("Sprite").GetComponent<Image>();



        _model = model;

        _model
            .IsVisible
            .Subscribe(onNext: isVisible => IsVisibleCall(isVisible))
            .AddTo(_disposables);

        _model
            .color
            .Subscribe(onNext: Color => ChangeColorCall(Color))
            .AddTo(_disposables);

        _model
            .sprite
            .Subscribe(onNext: Sprite => ChangeSpriteCall(Sprite)).AddTo(_disposables);

        _mainMenuButton.onClick.AddListener(call: () => MainMenuButton());

        _changeColorButton.onClick.AddListener(call: () => ChangeColorButton());

        _changeSpriteButton.onClick.AddListener(call: () => ChangeSpriteButton());

    }

    void IsVisibleCall(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    void ChangeColorCall(Color newColor)
    {
        _color.color = newColor;
        Debug.Log("Color Changed");
    }
    
    void ChangeSpriteCall(Sprite newSprite)
    {
        _image.sprite = newSprite;
        Debug.Log("Sprite Changed");
    }

    void MainMenuButton()
    {
        _model.MainMenuButtonPressed.Execute();
    }

    void ChangeColorButton()
    {
        _model.changeColorButtonPressed.Execute();
    }

    void ChangeSpriteButton()
    {
        _model.changeSpriteButtonPressed.Execute();
    }
}
