using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using static Obeliskial_Essentials.Essentials;
using Obeliskial_Essentials;
using System.IO;
using UnityEngine;
using System;
using static ZealotSkin.Traits;
using BepInEx.Configuration;

namespace ZealotSkin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.stiffmeds.obeliskialessentials")]
    [BepInDependency("com.stiffmeds.obeliskialcontent")]
    [BepInProcess("AcrossTheObelisk.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal int ModDate = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
        private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);
        internal static ManualLogSource Log;

        // public static ConfigEntry<bool> EnableDebugging { get; set; }


        public static string characterName = "ZealotSkin";
        public static string heroName = characterName;

        public static string subclassName = "ZealotSkin"; // needs caps

        public static string subclassname = subclassName.ToLower();
        public static string itemStem = subclassname;
        public static string debugBase = "Binbin - Testing " + characterName + " ";

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"{PluginInfo.PLUGIN_GUID} {PluginInfo.PLUGIN_VERSION} has loaded!");

            // EnableDebugging = Config.Bind(new ConfigDefinition(subclassName, "Enable Debugging"), true, new ConfigDescription("Enables debugging logs."));

            // register with Obeliskial Essentials
            RegisterMod(
                _name: PluginInfo.PLUGIN_NAME,
                _author: "binbin",
                _description: "Zealot Skin.",
                _version: PluginInfo.PLUGIN_VERSION,
                _date: ModDate,
                _link: @"https://github.com/binbinmods/ZealotSkin",
                _contentFolder: "ZealotSkin",
                _type: ["content", "hero", "trait"]
            );
            // apply patches
            // string text = "Shuffle your Vanish Pile into your Draw Pile.\n";
            // medsTexts[itemStem + "ZealotSkinformula"] = text;
            // medsTexts[itemStem + "ZealotSkinformulaa"] = text;
            // medsTexts[itemStem + "ZealotSkinformulab"] = text;
            // CardDescriptionNew.AddTextToCardDescription(text, CardDescriptionNew.TextLocation.Beginning, "ZealotSkinformula");
            // CardDescriptionNew.AddTextToCardDescription(text, CardDescriptionNew.TextLocation.Beginning, "ZealotSkinformulaa");
            // CardDescriptionNew.AddTextToCardDescription(text, CardDescriptionNew.TextLocation.Beginning, "ZealotSkinformulab");

            // harmony.PatchAll();
        }

        internal static void LogDebug(string msg)
        {
            // if (EnableDebugging.Value)
            // {
            // Log.LogDebug(debugBase + msg);
            // }

        }
        internal static void LogInfo(string msg)
        {
            Log.LogInfo(debugBase + msg);
        }
        internal static void LogError(string msg)
        {
            Log.LogError(debugBase + msg);
        }
    }
}
