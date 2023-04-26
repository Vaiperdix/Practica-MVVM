using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DoubleClic : MonoBehaviour
{
    private void Start()
    {
        var clickStream = Observable.EveryUpdate()
    .Where(_ => Input.GetMouseButtonDown(0));

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs => Debug.Log("DoubleClick Detected! Count:" + xs.Count));


        var progressNotifier = new ScheduledNotifier<float>();
        progressNotifier.Subscribe(x => Debug.Log(x)); // write www.progress

        // pass notifier to WWW.Get/Post
        ObservableWWW.Get("http://google.com/", progress: progressNotifier).Subscribe();
    }
}
