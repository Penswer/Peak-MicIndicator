using BepInEx;
using UnityEngine;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using Zorro.Core.Serizalization;
using pworld.Scripts;
using HarmonyLib;
using BepInEx.Configuration;
using UnityEngine.UI;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using ExitGames.Client.Photon.StructWrapping;
using Sirenix.Utilities;
using Unity.Collections;

namespace MicIndicator;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static EventComponent Component;

    public static ConfigEntry<KeyCode> configToggleKey;
    public static ConfigEntry<bool> configIsActive;
    public static ConfigEntry<Vector2> configPosition;
    public static ConfigEntry<float> configScale;

    internal static Texture2D micOnTex = null;
    internal static Texture2D micOffTex = null;

    internal static bool itsTimeXD = false;

    private void Awake()
    {
        // Plugin startup logic
        configToggleKey = Config.Bind("Keybinds", "ToggleKey", KeyCode.End, "The key used to toggle the GUI on and off");
        configIsActive = Config.Bind("GUI", "IsActive", true, "If the icon is showing");
        configPosition = Config.Bind("GUI", "Position", new Vector2(-920f, -370f), "The position of the icon");
        configScale = Config.Bind("GUI", "Scale", 5.0f, "The scale of the icon");
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        foreach (var option in Environment.GetCommandLineArgs())
        {
            Logger.LogInfo($"Launch Options {option}.!");
        }
        Component = this.gameObject.AddComponent<EventComponent>();
        micOnTex = GetTextureFromAssemImage("MicIndicator.Images.MicOn.png");
        micOffTex = GetTextureFromAssemImage("MicIndicator.Images.MicOff.png");
        itsTimeXD = true;
        // micIcon.GetComponent<RawImage>()
    }

    internal Texture2D GetTextureFromAssemImage(string imageName)
    {
        // Assembly.GetExecutingAssembly().GetManifestResourceNames().ForEach((x) => { Logger.LogError(x); });
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imageName))
        {
            if (stream == null)
            {
                Logger.LogError("COULD NOT FIND MIC ICON. REPORT THIS TO MOD MAKER");
                return null;
            }
            var image = System.Drawing.Image.FromStream(stream);
            Texture2D tex = new Texture2D(image.Width, image.Height);
            using (var memStream = new MemoryStream())
            {
                image.Save(memStream, ImageFormat.Png);
                tex.LoadImage(memStream.ToArray());
                tex.Apply();
            }
            return tex;
        }
    }

}
