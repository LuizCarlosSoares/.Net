 using GraphQL.Types;
using gql.core.repository;
using gql.core.model;
using NHLStats.Api.Models;

namespace gql.api.models
{
    public class CompanyMutation : ObjectGraphType
    {
        public CompanyMutation(ICompanyRepository companyRepository)
        {
            Name = "CreatePlayerMutation";

            Field<CompanyType>(
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