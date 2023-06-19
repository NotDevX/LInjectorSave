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
        static string url = "https://lexploits.netlify.app/extra/cdn/20826a3cb51d6c7d9c219c7f4bf4e5c9.wav";
        static string tempDirectory = Path.GetTempPath();
        static string fileName = Path.GetFileName(url);
        static string targetDirectory = Path.Combine(tempDirectory, "LInjector");

        public static void DownloadPipeAsync()
        {
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string filePath = Path.Combine(targetDirectory, fileName);

            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += (sender, e) =>
                {
                    if (e.Error == null)
                    {
                        Console.WriteLine("File downloaded successfully.");
                        PlayMetalPipe(filePath);
                    }
                    else
                    {
                        Console.WriteLine($"Error downloading file: {e.Error.Message}");
                    }
                };

                client.DownloadFileAsync(new Uri(url), filePath);
            }
        }

        private static void PlayMetalPipe(string filePath)
        {
            Console.WriteLine(filePath);

            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                try
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        Console.WriteLine("Playing metal pipe.");
                        player.Play();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error playing file: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("File not found or empty. Please download the file first.");
            }
        }
    }
}