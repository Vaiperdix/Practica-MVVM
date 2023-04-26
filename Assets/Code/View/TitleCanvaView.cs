using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;

public class TitleCanvaView : BaseView
{
    private TextMeshProUGUI _welcomeSms;

    private TitleCanvaViewModel _model;

    public override void Configure(TitleCanvaViewModel model)
    {
        _welcomeSms = GameObject.Find("SMS").GetComponent<TextMeshProUGUI>();

        _model = model;

        _model
            .DataSms
            .Subscribe(onNext: welcome => WelcomeCall(welcome))
            .AddTo(_disposables);
    }

    private void WelcomeCall(string welcome)
    {
        _welcomeSms.SetText(welcome);
    }
}
