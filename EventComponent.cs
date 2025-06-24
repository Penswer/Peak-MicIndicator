using UnityEngine;
using System;
using MicIndicator;

public class EventComponent : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(Plugin.configKeyBind.Value))
        {
        }

    }

    void OnGUI()
    {
    }

    void LateUpdate()
    {
    }

    void Start()
    {
        Action act = () =>
        {
        };
        // this.StartCoroutine(ButtonAPI.WaitForQMClone(act).WrapToIl2Cpp());
    }

}