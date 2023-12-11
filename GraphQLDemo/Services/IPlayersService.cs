using GraphQLDemo.Models;

namespace GraphQLDemo.Services
{
    public interface IPlayersService
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
    }
}
