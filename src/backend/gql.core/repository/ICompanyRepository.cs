using System.Collections.Generic;
using System.Threading.Tasks;
using gql.core.model;


namespace gql.core.repository
{
    public interface ICompanyRepository
    {
         Task<Company> Get(int id);
         Task<IList<Company>> All();
         Task<Company> Add(Company company);
    }
}