using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Code9.Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CinemaRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cinema>> GetAllCinemas()
        {
            return await _dbContext.Cinemas.ToListAsync();
        }

        public async Task<Cinema> AddCinema(Cinema newCinema)
        {
            _dbContext.Cinemas.Add(newCinema);
            await _dbContext.SaveChangesAsync();
            return newCinema;
        }

        public async Task<Cinema> UpdateCinema(Cinema cinema)
        {
            _dbContext.Cinemas.Update(cinema);
            await _dbContext.SaveChangesAsync();
            return cinema;
        }
    }
}