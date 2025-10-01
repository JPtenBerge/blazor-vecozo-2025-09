using Demo.Shared.Entities;
using Demo.Shared.Repositories;

namespace DemoProject.Endpoints;

public static class BurgerEndpoints
{
    public static void MapBurgerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/burgers").WithTags("Burgers");
        group.MapGet("/", GetAll);
        group.MapPost("/", Post);
    }

    public static async Task<IEnumerable<Burger>> GetAll(IBurgerRepository burgerRepository)
    {
        return await burgerRepository.GetAllAsync();
    }

    public static async Task<Burger> Post(IBurgerRepository burgerRepository, Burger newBurger)
    {
        return await burgerRepository.AddAsync(newBurger);
    }
}
