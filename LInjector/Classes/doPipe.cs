using System;
using System.IO;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class doPipe
    {
        static string metalPipeURL = "https://lexploits.netlify.app/extra/cdn/20826a3cb51d6c7d9c219c7f4bf4e5c9.wav";
        static string bambooPipeURL = "https://lexploits.netlify.app/extra/cdn/82960335036ff4ddc124b78af7777ee4.wav";
        static string tempDirectory = Path.GetTempPath();
        static string fileNameMetal = Path.GetFileName(metalPipeURL);
        static string fileNameBamboo = Path.GetFileName(bambooPipeURL);
        static string targetDirectory = Path.Combine(tempDirectory, "LInjector");
        public static string selectedArg;

        // METAL PIPE

        public static void doMetalPipeAsync()
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string filePath = Path.Combine(targetDirectory, fileNameMetal);

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                        cwDt.CwDt("File downloaded successfully.");
                        selectedArg = filePath;
                    }
                    else
                    {
                        cwDt.CwDt($"Error downloading file: {e.Error.Message}");
                    }
                };

                client.DownloadFileAsync(new Uri(metalPipeURL), filePath);
            }
        }

        // BAMBOO PIPE

        public static void doBambooPipeAsync()
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string filePath = Path.Combine(targetDirectory, fileNameBamboo);

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                        cwDt.CwDt("File downloaded successfully.");
                        selectedArg = filePath;
                    }
                    else
                    {
                        cwDt.CwDt($"Error downloading file: {e.Error.Message}");
                    }
                };

                client.DownloadFileAsync(new Uri(bambooPipeURL), filePath);
            }
        }

        public static void PlayPipeSound (string filePath)
        {
            cwDt.CwDt(filePath);

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        cwDt.CwDt("Playing pipe.");
                        player.Play();
                    }
                }
                catch (Exception e)
                {
                    cwDt.CwDt($"Error playing file: {e.Message}");
                }
            }
            else
            {
                cwDt.CwDt(filePath);
            }
        }
    }
}