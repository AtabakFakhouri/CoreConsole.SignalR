using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreConsole.SignalR.Server;
class PeriodicHostedService : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromSeconds(3);    
    private readonly IServiceScopeFactory _factory;
    public bool IsEnabled { get; set; }

    public PeriodicHostedService(IServiceScopeFactory factory)
    {
        _factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        using PeriodicTimer timer = new PeriodicTimer(_period); 
        await timer.WaitForNextTickAsync(stoppingToken);
        while (
        !stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Enter text: ");            
            var enteredText = Console.ReadLine();
            if(enteredText != null)
            {                
                await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                SignalRHub sampleService = asyncScope.ServiceProvider.GetRequiredService<SignalRHub>();
                await sampleService.SendText(enteredText);
            }
        }
    }
}
