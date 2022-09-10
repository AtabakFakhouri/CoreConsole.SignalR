using Microsoft.AspNetCore.SignalR.Client;

namespace CoreConsole.SignalR.Client;
internal class Program
{
    public const string wssUrl = "http://host.docker.internal:80/signalRHub";
    static void Main(string[] args)
    {        
        Thread.Sleep(2000);  
        
        var connectionSignalR = new HubConnectionBuilder()               
           .WithUrl(wssUrl)               
           .Build();
        connectionSignalR.StartAsync().Wait();

        Console.WriteLine("SignalR Conncected, Write anything in server console");        
        connectionSignalR.On<string>("RecieveText",text=>Console.WriteLine(text));
        Console.Read();

        
    }
}