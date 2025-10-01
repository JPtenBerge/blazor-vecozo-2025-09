using Demo.Shared.Entities;
using Demo.Shared.Repositories;
using Flurl.Http;

namespace BlazorApp1.Client.Repositories;

public class BurgerRepository : IBurgerRepository
{
    public async Task<IEnumerable<Burger>> GetAllAsync()
    {
        return await "https://localhost:7270/api/burgers".GetJsonAsync<IEnumerable<Burger>>();
    }

    public async Task<Burger> AddAsync(Burger newBurger)
    {
        return await "https://localhost:7270/api/burgers"
            .PostJsonAsync(newBurger)
            .ReceiveJson<Burger>();
    }
}
