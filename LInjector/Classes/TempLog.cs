using System.IO;

namespace LInjector.Classes
{
    public static class TempLog
    {
        public static void CreateVersionFile(string content, string fileName)
        {
            var tempPath = Path.GetTempPath();
            var linjectorFolderPath = Path.Combine(tempPath, "LInjector");
            var versionFilePath = Path.Combine(linjectorFolderPath, fileName);

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
