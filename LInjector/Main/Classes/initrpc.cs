using DiscordRPC;

namespace LInjector.Classes
{
    public static class DiscordRPCManager
    {
        private static DiscordRpcClient client;

        public static void InitRPC()
        {
            var inmainpresence = new RichPresence()
            {
                Details = "Using LInjector",
                State = "Exploiting",
                Assets = new Assets()
                {
                    LargeImageKey = "https://lexploits.netlify.app/extra/cdn/LInjector%20ico.png",
                    LargeImageText = "by The LExploits Project.",
                }
            };

            client = new DiscordRpcClient("1104489169314660363");
            client.Initialize();
            client.SetPresence(inmainpresence);
        }
    }
}