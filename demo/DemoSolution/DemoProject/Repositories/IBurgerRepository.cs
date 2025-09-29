using DemoProject.Entities;

namespace DemoProject.Repositories;

public interface IBurgerRepository
{
    Task<Burger> AddAsync(Burger newBurger);
    Task<IEnumerable<Burger>> GetAllAsync();
}