using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class OptionMenuUseCase : OptionMenuRequest
{

    Color newColor = Color.black;
    Sprite newSprite = Resources.Load<Sprite>("Sprite Folder/sprite1");

    public async Task MainMenu()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5f));

        var data = new WelcomeData(welcome: "Menu Principal!!");

        EventDispatcherService.Instance.Dispatch(data);
    }

    public async Task ChangeColor()
    {
        await Task.Delay(TimeSpan.FromSeconds(0f));

        newColor = SelectColor(RamdonColor());

        ChangeOptionData();
    }
    
    public async Task ChangeSprite()
    {
        await Task.Delay(TimeSpan.FromSeconds(0f));

        newSprite = SelectSprite(RamdonColor());

        ChangeOptionData();
    }

    public void ChangeOptionData()
    {
        var data = new OptionData(color: newColor, newSprite);

        EventDispatcherService.Instance.Dispatch(data);
    }


    private int RamdonColor()
    {
        var x = UnityEngine.Random.Range(0,5);
        return x;
    }

    private Color SelectColor(int color)
    {
        switch (color)
        {
            case 0:
                return Color.white;
                break;
            case 1:
                return Color.green;
                break;
            case 2:
                return Color.blue;
                break;
            case 3:
                return Color.red;
                break;
            case 4:
                return Color.yellow;
                break;
            default:
                return Color.black;
                break;
        }
    }

    private Sprite SelectSprite(int sprite)
    {
        switch (sprite)
        {
            case 0:
                return Resources.Load<Sprite>("Sprite Folder/sprite1");
                break;
            case 1:
                return Resources.Load<Sprite>("Sprite Folder/sprite2");
                break;
            case 2:
                return Resources.Load<Sprite>("Sprite Folder sprite3");
                break;
            case 3:
                return Resources.Load<Sprite>("Sprite Folder/sprite4");
                break;
            case 4:
                return Resources.Load<Sprite>("Sprite Folder/sprite3");
                break;
            default:
                return Resources.Load<Sprite>("Sprite Folder/sprite2");
                break;
        }
    }
}
