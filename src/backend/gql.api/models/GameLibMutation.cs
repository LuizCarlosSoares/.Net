 using GraphQL.Types;
using gql.core.repository;
using gql.core.model;

namespace gql.api.models
{
    public class CompanyMutation : ObjectGraphType
    {
        public NHLStatsMutation(ICompanyRepository companyRepository)
        {
            Name = "CreateCompany";

            Field<PlayerType>(
                "createCompany",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CompanyInputType>> { Name = "company" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Company>("company");
                    return companyRepository.Add(player);
                });
        }
    }
}