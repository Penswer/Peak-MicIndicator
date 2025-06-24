using System;
using UnityEngine;
using MicIndicator;

public class CorRunner
{
    Coroutine cor;
    Func<System.Collections.IEnumerator> enumeratorFunc;

    public CorRunner(Func<System.Collections.IEnumerator> enumeratorFunc) {
        this.cor = null;
        this.enumeratorFunc = enumeratorFunc;
    }

    public void Start() {
        this.Stop();
        this.cor = Plugin.Component.StartCoroutine(enumeratorFunc());
    }

    public void Stop() {
        if (this.cor != null){
            Plugin.Component.StopCoroutine(cor);
            this.cor = null;
        }
    }

    public void Toggle(bool val){
        if (val){
            this.Start();
        } else{
            this.Stop();
        }
    }

}