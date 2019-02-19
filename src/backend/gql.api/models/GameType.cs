using gql.api.models;
using gql.core.model;
using gql.core.repository;
using GraphQL.Types;


namespace NHLStats.Api.Models
{
    public class GameType : ObjectGraphType<Game>
    {

        private IGameRepository gameRepository;
        public GameType(IGameRepository gameRepository, ICompanyRepository companyRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);           
        
            Field<CompanyType>("Developer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => companyRepository.Get(context.Source.Id), description: "Developer information");
        }
    }
}