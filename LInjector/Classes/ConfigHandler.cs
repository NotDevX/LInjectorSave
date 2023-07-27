using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LInjector.Classes
{
    public class ConfigHandler
    {
        private static readonly string ConfigPath = ".\\config.json";
        private static application GetApplication = new application();

        public static bool topmost = false;
        public static bool autoattach = false;
        public static bool nosplash = false;
        public static bool sizable = false;
        public static bool debug = false;
        public static bool discord_rpc = true;
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
                    { "debug", false },
                    { "topmost", false },
                    { "discord_rpc", true },
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
                    autoattach = true;
                    ConfigHandler ch = new ConfigHandler();
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

        public static void SetConfigValue(string Name, bool Value)
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

            string updatedJson = JsonConvert.SerializeObject(configDict, Formatting.Indented);
            File.WriteAllText(ConfigPath, updatedJson);
        }
    }
}