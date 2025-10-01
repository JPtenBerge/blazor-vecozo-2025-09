using BlazorApp1.Client.Repositories;
using Demo.Shared.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp1.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddTransient<IBurgerRepository, BurgerRepository>();
        await builder.Build().RunAsync();
    }
}
