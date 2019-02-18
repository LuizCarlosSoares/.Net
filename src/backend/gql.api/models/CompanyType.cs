using gql.core.model;
using gql.core.repository;
using GraphQL.Types;


namespace NHLStats.Api.Models
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType(ICompanyRepository companyRepository,IGameRepository gameRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);        
            Field<ListGraphType<GameType>>("Games",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => gameRepository.Get(context.Source.Id), description: "Developed Games");
        }
    }
}