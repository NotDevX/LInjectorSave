using LInjector.Forms.Menus;
using LInjector.WPF;
using LInjector.WPF.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class ConfigHandler
    {
        private static readonly string ConfigPath = ".\\config.json";
        public static System.Windows.Forms.Timer GetTimer = new System.Windows.Forms.Timer();
        private static application GetApplication = new application();
        public static bool topmost = false;

        public static bool autoattach = false;
        public static bool nosplash = false;
        public static bool sizable = false;
        public static bool debug = false;
        public static bool discord_rpc = true;
        public static int Opacity = 100;
        public static void DoConfig()
        {
            if (!File.Exists(ConfigPath))
            {
                var config = new Dictionary<string, object>
                {
                    { "autoattach", false },
                    { "nosplash", false },
                    { "metalpipe", false },
                    { "bamboopipe", false },
                    { "sizable", false },
                    { "debug", false },
                    { "topmost", false },
                    { "discord_rpc", true },
                    { "opacity", 100 }
                };

                string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);

                File.WriteAllText(ConfigPath, jsonString);
            }
            else if (File.Exists(ConfigPath))
            {
                string jsonString = File.ReadAllText(ConfigPath);
                var config = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

                if (config.TryGetValue("autoattach", out object autoAttachValue) && (bool)autoAttachValue)
                {
                    StartListening();
                    settings GetSettings = new settings();
                    autoattach = true;
                }

                if (config.TryGetValue("nosplash", out object noSplashValue) && (bool)noSplashValue)
                {
                    ArgumentHandler.splashEnabled = false;
                    nosplash = true;
                }

                if (config.TryGetValue("metalpipe", out object metalPipeValue) && (bool)metalPipeValue)
                {
                    DoPipe.doMetalPipeAsync();
                }

                if (config.TryGetValue("bamboopipe", out object bambooPipeValue) && (bool)bambooPipeValue)
                {
                    DoPipe.doBambooPipeAsync();
                }

                if (config.TryGetValue("sizable", out object sizableValue) && (bool)sizableValue)
                {
                    ArgumentHandler.SizableBool = true;
                    sizable = true;
                }

                if (config.TryGetValue("debug", out object debugValue) && (bool)debugValue)
                {
                    ConsoleManager.Initialize();
                    ConsoleManager.ShowConsole();
                    debug = true;
                }

                if (config.TryGetValue("topmost", out object topMostValue) && (bool)topMostValue)
                {
                    topmost = true;
                }

                if (config.TryGetValue("discord_rpc", out object discord_rpc) && (bool)discord_rpc)
                {
                    RPCManager.isEnabled = true;
                    discord_rpc = true;
                }
            }
        }

        public static void StartListening() 
        {
            GetTimer.Enabled = true;
            GetTimer.Interval = 100;

            GetTimer.Tick += (sender, e) =>
            {
                Process[] Roblox = Process.GetProcessesByName("Windows10Universal");
                if (Roblox.Length > 0)
                {
                    FluxusAPI.create_files(Path.GetFullPath("Resources\\libs\\Module.dll"));
                    if (!FluxusAPI.is_injected(FluxusAPI.pid))
                    {
                        GetApplication.Inject();
                    }
                    bool flag = FluxusAPI.is_injected(FluxusAPI.pid);
                    if (flag)
                    {
                        GetTimer.Stop();
                    }
                }
            };
        }

        public static void StopListening() 
        {
            GetTimer.Stop();
        }

        public static void SetConfigValue(string Name, object Value)
        {
            string jsonContent = File.ReadAllText(ConfigPath);
            var configDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);

            if (configDict.ContainsKey(Name))
            {
                configDict[Name] = Value;
            }
            else
            {
                CwDt.Cw($"The value '{Name}' doesn't exist in the config");
                return;
            }

            if (Name == "Opacity" && Value is int intValue)
            {
                configDict[Name] = intValue;
            }

            string updatedJson = JsonConvert.SerializeObject(configDict, Formatting.Indented);
            File.WriteAllText(ConfigPath, updatedJson);
        }
    }
}