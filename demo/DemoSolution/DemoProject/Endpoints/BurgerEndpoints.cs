using Demo.Shared.Entities;
using Demo.Shared.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DemoProject.Endpoints;

public static class BurgerEndpoints
{
    public static void MapBurgerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/burgers").WithTags("Burgers");
        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", Get);
        group.MapPost("/", Post);
    }

    public static async Task<IEnumerable<Burger>> GetAll(IBurgerRepository burgerRepository)
    {
        return await burgerRepository.GetAllAsync();
    }

    public static async Task<Results<NotFound<string>, Ok<Burger>>> Get(IBurgerRepository burgerRepository, int id)
    {
        var allBurgers = await burgerRepository.GetAllAsync();
        var theBurger = allBurgers.SingleOrDefault(b => b.Id == id);
        if (theBurger is null)
        {
            return TypedResults.NotFound($"Could not find burger with id {id}");
        }


        return TypedResults.Ok(theBurger);
    }

    public static async Task<Burger> Post(IBurgerRepository burgerRepository, Burger newBurger)
    {
        return await burgerRepository.AddAsync(newBurger);
    }
}
