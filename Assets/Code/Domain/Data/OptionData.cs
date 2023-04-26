using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionData : MonoBehaviour
{
    public readonly Color spriteColor;
    public readonly Sprite spriteName;

    public OptionData(Color color, Sprite sprite)
    {
        spriteColor = color;
        spriteName = sprite;
    }

    public OptionData(Sprite sprite)
    {
        spriteName = sprite;
    }

    public OptionData()
    {

    }

}
