using Octokit;
using System;
using System.Linq;

namespace LInjector.Classes
{
    public class CheckLatest
    {
        private const string owner = "ItzzExcel";
        private const string repo = "LInjector";

        public static bool IsOutdatedVersion(string currentVersion)
        {
            if (currentVersion == "f81fb0e34f313b6cf0d0fc345890a33f")
            { return false; }

            var client = new GitHubClient(new ProductHeaderValue("CheckGitHubRelease"));

            var releases = client.Repository.Release.GetAll(owner, repo).Result;

            var latestRelease = releases
                .Where(r => r.TagName.StartsWith("v"))
                .OrderByDescending(r => r.PublishedAt)
                .FirstOrDefault();

            if (latestRelease != null)
            {
                var latestVersion = latestRelease.TagName.TrimStart('v');

                Version current = null;
                if (Version.TryParse(currentVersion.TrimStart('v'), out current))
                {
                    Version latest;
                    if (Version.TryParse(latestVersion, out latest))
                    {
                        return current < latest;
                    }
                }
            }

            return false;
        }
    }
}