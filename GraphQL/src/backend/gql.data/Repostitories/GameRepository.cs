using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gql.core.model;
using gql.core.repository;
using Microsoft.EntityFrameworkCore;

namespace gql.data.repository {

    public class GameRepository : IGameRepository {

        private readonly CoreDbContext db;

        GameRepository (CoreDbContext dbContext) {
            db = dbContext;
        }

        public async Task<Game> Get (int id) {
            return await db.Games.FirstOrDefaultAsync (x => x.Id.Equals (id));
        }

        public async Task<IList<Game>> All () {
            return await db.Games.OrderBy(c => c.Name).ToListAsync ();
        }

        public async Task<Game> Add (Game game) {

            await db.Games.AddAsync (game);
            await db.SaveChangesAsync ();
            return game;

        }

    }

}
