using System;
using System.Linq;
using Octokit;

namespace LInjector
{
    public class GitHubVersionChecker
    {
        private const string owner = "ItzzExcel";
        private const string repo = "LInjector";

        public static bool IsOutdatedVersion(string currentVersion)
        {
            var client = new GitHubClient(new ProductHeaderValue("CheckGitHubRelease"));

            var releases = client.Repository.Release.GetAll(owner, repo).Result;

            var latestRelease = releases
                .Where(r => r.TagName.StartsWith("v"))
                .OrderByDescending(r => r.PublishedAt)
                .FirstOrDefault();

            if (latestRelease != null)
            {
                var latestVersion = latestRelease.TagName.TrimStart('v');

                var current = Version.Parse(currentVersion.TrimStart('v'));
                var latest = Version.Parse(latestVersion);

                return current < latest;
            }

            return false;
        }
    }
}