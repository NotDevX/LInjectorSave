using System.IO;

namespace LInjector.Classes
{
    public static class tempLog
    {
        public static void CreateVersionFile(string content)
        {
            string tempPath = Path.GetTempPath();
            string linjectorFolderPath = Path.Combine(tempPath, "LInjector");
            string versionFilePath = Path.Combine(linjectorFolderPath, "version");

            if (!Directory.Exists(linjectorFolderPath))
            {
                Directory.CreateDirectory(linjectorFolderPath);
            }

            if (!File.Exists(versionFilePath))
            {
                File.WriteAllText(versionFilePath, content);
            }
        }
    }
}