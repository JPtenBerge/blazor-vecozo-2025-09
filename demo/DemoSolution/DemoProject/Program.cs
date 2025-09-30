using DemoProject.Components;
using DemoProject.DataAccess;
using DemoProject.Endpoints;
using DemoProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        //builder.Services.AddTransient<IBurgerRepository, BurgerRepository>();
        builder.Services.AddTransient<IBurgerRepository, BurgerDbRepository>();
        builder.Services.AddDbContextFactory<DemoContext>(opts =>
        {
            opts.UseSqlServer(builder.Configuration.GetConnectionString("DemoContext"));
        }, ServiceLifetime.Transient);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapBurgerEndpoints();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
