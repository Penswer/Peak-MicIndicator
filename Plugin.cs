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

namespace MicIndicator;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    internal static EventComponent Component;
    
    public static ConfigEntry<KeyCode> configKeyBind;

    private void Awake()
    {
        // Plugin startup logic
        configKeyBind = Config.Bind("Keybinds", "ToggleKey", KeyCode.Home, "The key used to toggle the GUI on and off");
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        foreach (var option in Environment.GetCommandLineArgs())
        {
            Logger.LogInfo($"Launch Options {option}.!");
        }
        Component = this.gameObject.AddComponent<EventComponent>();
    }

}
