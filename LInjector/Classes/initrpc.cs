using DiscordRPC;

namespace LInjector
{
    public class DiscordRPCManager
    {
        private DiscordRpcClient client;

        public void InitRPC()
        {
            var inmainpresence = new RichPresence()
            {
                Details = "Using LInjector by LExploits",
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