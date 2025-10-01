using Demo.Shared.Entities;

namespace Demo.Shared.Repositories;

public interface IBurgerRepository
{
    Task<Burger> AddAsync(Burger newBurger);
    Task<IEnumerable<Burger>> GetAllAsync();
}