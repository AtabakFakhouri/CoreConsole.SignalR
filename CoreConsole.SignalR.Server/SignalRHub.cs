using Microsoft.AspNetCore.SignalR;

namespace CoreConsole.SignalR.Server;

public class SignalRHub:Hub
{
    public Task SendText(string text)
    {
        if(Clients!=null)
        return Clients.All.SendAsync("RecieveText", text);

        Console.WriteLine("All clients are offline.");
        return Task.CompletedTask;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}
