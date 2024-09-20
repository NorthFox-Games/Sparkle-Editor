using DiscordRPC;
using DiscordRPC.Logging;
using Sparkle.CSharp.Logging;

namespace Sparkle_Editor.Code;

public static class DiscordManager
{
    public static DiscordRpcClient Client;

    //Called when your application first starts.
    //For example, just before your main loop, on OnEnable for unity.
    public static void Initialize() 
    {
        /*
        Create a Discord Client
        NOTE:   If you are using Unity3D, you must use the full constructor and define
                 the pipe connection.
        */
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
            }
        }); 
    }
}