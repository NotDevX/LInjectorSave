﻿using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace LInjector.Classes
{
    internal static class Files
    {
        public static readonly string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string RobloxACFolder = Path.Combine(localAppDataFolder, "Packages", "ROBLOXCORPORATION.ROBLOX_55nm5eh3cm0pr", "AC");
        public static readonly string workspaceFolder = Path.Combine(RobloxACFolder, "workspace");
        public static readonly string autoexecFolder = Path.Combine(RobloxACFolder, "autoexec");
        public static readonly string ModulePath = "Resources\\libs\\Module.dll";
        public static readonly string GithubAPI = "https://api.github.com/repos/ItzzExcel/LInjector/commits?path={0}&page=1&per_page=1";
        public static readonly string DLLSURl = "https://raw.githubusercontent.com/ItzzExcel/LInjector/master/Redistributables/DLLs";
        public static readonly string FluxusAPI = $"{DLLSURl}/FluxteamAPI.dll";
        public static readonly string ModuleAPI = $"{DLLSURl}/Module.dll";
    }

    public static class Updater
    {
        public static async Task CheckForUpdates()
        {
            try
            {
                string Local_Flux = RegistryHandler.GetValue("FluxVersion", "0");
                string Local_Module = RegistryHandler.GetValue("ModuleVersion", "0");

                string GitHub_Module = await GetHash("Redistributables/DLLs/Module.dll");
                string GitHub_Flux = await GetHash("Redistributables/DLLs/FluxteamAPI.dll");

                if (!File.Exists(Files.ModulePath) || Local_Flux != GitHub_Flux || Local_Module != GitHub_Module)
                {
                    CreateFiles.RedownloadModules();

                    RegistryHandler.SetValue("FluxVersion", GitHub_Flux);
                    RegistryHandler.SetValue("ModuleVersion", GitHub_Module);

                    CustomCw.Cw("Registry values in Computer\\HKEY_CURRENT_USER\\SOFTWARE\\LInjector saved", false, "info");
                }

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckForUpdates: " + ex.InnerException.Message);
            }
        }

        private static async Task<string> GetHash(string path)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                    string url = string.Format(Files.GithubAPI, path);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dynamic data = JsonConvert.DeserializeObject(json);

                        if (data != null && data.Count > 0)
                        {
                            return data[0].sha;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetHash: " + ex.Message);
                return null;
            }
        }
    }

    public static class RegistryHandler
    {
        public static string GetValue(string name, string fallback)
        {
            try
            {
                var registryAddress = "SOFTWARE\\LInjector";
                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(registryAddress))
                {
                    string returnValue = fallback;
                    if (reg == null)
                    {
                        using (var newKey = Registry.CurrentUser.CreateSubKey(registryAddress))
                        {
                            if (newKey != null)
                            {
                                newKey.Close();
                            }
                            else
                            {
                                Console.WriteLine("Could not create the SubKey");
                                return fallback;
                            }
                        }
                    }

                    var value = reg.GetValue(name);
                    if (value != null)
                    {
                        returnValue = value.ToString();
                    }
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetValue: " + ex.Message);
                return fallback;
            }
        }

        public static void SetValue(string name, string value)
        {
            try
            {
                var registryAddress = "SOFTWARE\\LInjector";
                using (RegistryKey reg = Registry.CurrentUser.OpenSubKey(registryAddress, true))
                {
                    if (reg == null)
                    {
                        using (var newKey = Registry.CurrentUser.CreateSubKey(registryAddress))
                        {
                            if (newKey != null)
                            {
                                newKey.Close();
                            }
                            else
                            {
                                Console.WriteLine("Could not create the SubKey");
                                return;
                            }
                        }
                    }

                    reg.SetValue(name, value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SetValue: " + ex.Message);
            }
        }
    }
}