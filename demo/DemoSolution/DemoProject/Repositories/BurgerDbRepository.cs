using DemoProject.DataAccess;
using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class BurgerDbRepository : IBurgerRepository
{
    private readonly DemoContext _context;
    public BurgerDbRepository(DemoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Burger>> GetAllAsync()
    {
        return await _context.Burgers.ToArrayAsync();
    }

    public async Task<Burger> AddAsync(Burger newBurger)
    {
        _context.Burgers.Add(newBurger);
        await _context.SaveChangesAsync();
        return newBurger; // Id has been set after SaveChanges()
    }
}
