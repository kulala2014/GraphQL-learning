using GraphQLDemo.Data;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly SportsDbContext _context;

        public PlayersService(SportsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _context.Players.Include(x => x.Position).ToListAsync();
        }
    }
}
