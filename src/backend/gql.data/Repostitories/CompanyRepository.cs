using gql.core.repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gql.core.model;

namespace gql.data.Repostitories {

    public class CompanyRepository : ICompanyRepository {

        private readonly CoreDbContext db;

        CompanyRepository (CoreDbContext dbContext) {
            db = dbContext;
        }

        public async Task<Company> Get (int id) {
            return await db.Companies.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IList<Company>> All() {
            return await db.Companies.OrderBy(c=>c.Name).ToListAsync();
        }

         public async Task<Company> Add(Company company) {
            
            await db.Companies.AddAsync(company);
            await db.SaveChangesAsync();
            return company;

        }

    }
    
}