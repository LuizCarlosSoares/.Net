using gql.core.model;
using gql.core.repository;
using GraphQL.Types;


namespace gql.api.models
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType(ICompanyRepository companyRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.Country);

        }
    }
}