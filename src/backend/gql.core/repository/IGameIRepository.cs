using System.Collections.Generic;
using System.Threading.Tasks;
using gql.core.model;

namespace gql.core.repository
{
    public interface IGameRepository
    {
         Task<Game> Get(int id);
         Task<IList<Game>> All();
         Task<Game> Add(Game game);
    }
}