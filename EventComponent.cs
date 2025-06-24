using UnityEngine;
using System;
using MicIndicator;
using Photon.Voice.PUN;
using UnityEngine.UI;
using Photon.Voice;

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
                    // micIconLocal.transform.localScale = new Vector3(Plugin.configScale.Value, Plugin.configScale.Value, Plugin.configScale.Value);
                    // micIconLocal.transform.localPosition = new Vector3(Plugin.configPosition.Value.x, Plugin.configPosition.Value.y, 0.0f);
                    RectTransform rect = micIconLocal.transform as RectTransform;
                    rect.anchoredPosition = new Vector2(Plugin.configPosition.Value.x, Plugin.configPosition.Value.y);
                    rect.sizeDelta = new Vector2(Plugin.configScale.Value, Plugin.configScale.Value);
                    rect.anchorMax = new Vector2(0, 0);
                    rect.anchorMin = new Vector2(0, 0);
                    rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
                    var meter = micView.RecorderInUse.LevelMeter;
                    // var voiceAudio = ConstantFields.GetVoiceAudioField().GetValue(recorder) as LocalVoiceAudioFloat;
                    // var level = voiceAudio.LevelMeter;
                    if (micView.IsRecording && ((float)ConstantFields.GetVoiceAudioField().GetValue((meter))) > Plugin.configMicDetectionThreshold.Value)
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
                    if (Character.localCharacter != null)
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