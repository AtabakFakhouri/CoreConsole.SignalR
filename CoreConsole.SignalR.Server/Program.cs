using CoreConsole.SignalR.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<SignalRHub>();
//builder.Services.AddLogging(
//  builder =>
//  {
//      builder.AddFilter("Microsoft", LogLevel.Warning)
//             .AddFilter("System", LogLevel.Warning)
//             .AddFilter("NToastNotify", LogLevel.Warning)
//             .AddConsole();
//  });
builder.Services.AddHostedService<PeriodicHostedService>();
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<PeriodicHostedService>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SignalRHub>("/signalRHub");    
});

app.Run();

