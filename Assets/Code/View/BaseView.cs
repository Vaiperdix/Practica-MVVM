using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    protected List<IDisposable> _disposables = new List<IDisposable>();

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
            Debug.Log("Dispose");
        }
    }



    public virtual void Configure(MainMenuViewModel model)
    {
    }

    public virtual void Configure(OptionMenuViewModel model)
    {
    }

    public virtual void Configure(TitleCanvaViewModel model)
    {
    }
}
