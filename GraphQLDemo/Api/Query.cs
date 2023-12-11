using GraphQLDemo.Models;
using GraphQLDemo.Services;

namespace GraphQLDemo.Api
{
    public class Query
    {
        public async Task<IEnumerable<Player>> GetPlayersAsync([Service] IPlayersService playersService)
        {
            return await playersService.GetPlayersAsync();
        }
    }
}
