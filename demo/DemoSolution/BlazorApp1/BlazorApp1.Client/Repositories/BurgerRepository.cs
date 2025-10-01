using Demo.Shared.Entities;
using Demo.Shared.Repositories;

namespace BlazorApp1.Client.Repositories;

public class BurgerRepository : IBurgerRepository
{

    public Task<IEnumerable<Burger>> GetAllAsync()
    {
        var burgers = new List<Burger>
        {
            new() { Id = 4, Name = "McWerk", Price = 50000m, Rating = 2, PhotoUrl = ""}
        };
        return Task.FromResult(burgers.AsEnumerable());
    }

    public Task<Burger> AddAsync(Burger newBurger)
    {
        throw new NotImplementedException();
    }
}
