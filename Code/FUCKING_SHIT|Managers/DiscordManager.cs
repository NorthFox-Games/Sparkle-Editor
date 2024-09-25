using DiscordRPC;
using DiscordRPC.Logging;

namespace Sparkle_Editor.Code.Managers;

public static class DiscordManager
{
    public static DiscordRpcClient Client;

    /// <summary>
    /// Connect RPC and Subscribe to events
    /// </summary>
    public static void Initialize() 
    {
        Client = new DiscordRpcClient("1286649594268352613");          

        //Set the logger
        Client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

        //Subscribe to events
        Client.OnReady += (sender, e) =>
        {
            Console.WriteLine("Received Ready from user {0}", e.User.Username);
        };

        Client.OnPresenceUpdate += (sender, e) =>
        {
            Console.WriteLine("Received Update! {0}", e.Presence);
        };

        //Connect to the RPC
        Client.Initialize();

        //Set the rich presence
        //Call this as many times as you want and anywhere in your code.
        Client.SetPresence(new RichPresence()
        {
            Details = "Example Project",
            State = "Making some shit",
            Assets = new Assets()
            {
                LargeImageKey = "logo",
                LargeImageText = "Sparkle Editor"
            },
            Timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow
            },
            Buttons = new Button[] { new Button() {Label = "Our Discord", Url = "https://discord.gg/RxfMJjcJw2"}}
        }); 
    }
}