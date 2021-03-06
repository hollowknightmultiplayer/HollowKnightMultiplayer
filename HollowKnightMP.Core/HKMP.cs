﻿using System;
using System.IO;
using System.Reflection;
using HollowKnightMP.Debugging;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HollowKnightMP.Core
{
    public class HKMP
    {
        public static string ModAssetsDir { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Path.Combine(Environment.CurrentDirectory, @"hollow_knight_Data\Managed\Mods\HKMP");

        public static Texture2D logo;

        public HKMP()
        {
            logo = ImageUtils.LoadTextureFromFile(Path.Combine(ModAssetsDir, @"logo_white.png"));

            var netManager = new GameObject("Network Manager");
            netManager.AddComponent<NetworkManager>();
            netManager.AddComponent<NetworkCallbacks>();
            Object.DontDestroyOnLoad(netManager);

            CreateDebugger(netManager);
        }

        private void CreateDebugger(GameObject netManager)
        {
            GameObject debugger = new GameObject();
            debugger.name = "Debug manager";
            debugger.AddComponent<HKMPDebugManager>();
            debugger.transform.SetParent(netManager.transform);
        }
    }
}