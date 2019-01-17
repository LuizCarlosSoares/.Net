    using Microsoft.EntityFrameworkCore;

    namespace gql.data {

        public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<CoreDbContext> {
            protected override CoreDbContext CreateNewInstance (
                DbContextOptions<CoreDbContext> options) {
                return new CoreDbContext (options);
            }
        }
    }