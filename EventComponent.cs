using UnityEngine;
using System;
using MicIndicator;
using Photon.Voice.PUN;
using UnityEngine.UI;

public class EventComponent : MonoBehaviour
{
    RawImage micIcon = null;
    PhotonVoiceView micView = null;

    void Update()
    {

        if (Plugin.itsTimeXD)
        {
            if (micIcon == null)
            {
                var micIconLocal = GameObject.Find("/GAME/GUIManager/Canvas_HUD/Inventory/Layout/UI_InventoryBackpack/Icon/");
                var micIconLocalParent = GameObject.Find("/GAME/GUIManager/Canvas_HUD/");
                if (micIconLocal != null && micIconLocalParent != null)
                {
                    // micIcon = micIconLocal;
                    micIconLocal = GameObject.Instantiate(micIconLocal);
                    micIconLocal.transform.parent = micIconLocalParent.transform;
                    micIconLocal.transform.localScale = new Vector3(Plugin.configScale.Value, Plugin.configScale.Value, Plugin.configScale.Value);
                    micIconLocal.transform.localPosition = new Vector3(Plugin.configPosition.Value.x, Plugin.configPosition.Value.y, 0.0f);

                    // micIconLocal.SetActive(Plugin.configIsActive.Value);
                    RawImage micIconImageLocal = micIconLocal.GetComponent<RawImage>();
                    if (micIconImageLocal != null)
                    {
                        micIcon = micIconImageLocal;
                        micIcon.enabled = Plugin.configIsActive.Value;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(Plugin.configToggleKey.Value))
                {
                    Plugin.configIsActive.Value ^= true;
                    micIcon.enabled = Plugin.configIsActive.Value;
                }
                if (micView != null)
                {
                    if (micView.IsRecording)
                    {
                        micIcon.texture = Plugin.micOnTex;
                    }
                    else
                    {
                        micIcon.texture = Plugin.micOffTex;
                    }
                }
                else
                {
                    var view = Character.localCharacter?.GetComponent<PhotonVoiceView>();
                    if (view != null)
                    {
                        micView = view;
                    }
                }
            }
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
    }

}