using DemoProject.Entities;

namespace DemoProject.Repositories;

public interface IBurgerRepository
{
    Task AddAsync(Burger newBurger);
    Task<IEnumerable<Burger>> GetAllAsync();
}