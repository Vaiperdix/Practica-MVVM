using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TitleCanvaViewModel : MonoBehaviour
{
    public readonly ReactiveProperty<string> DataSms;
    public readonly ReactiveProperty<bool> IsVisible;


    public TitleCanvaViewModel()
    {
        DataSms = new StringReactiveProperty("Menu Principal");
    }
}
