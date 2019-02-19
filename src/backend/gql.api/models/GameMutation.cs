using gql.core.model;
using gql.core.repository;
using GraphQL.Types;
using NHLStats.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gql.api.models
{
    public class GameMutation : ObjectGraphType
    {
        public GameMutation(IGameRepository gameRepository)
        {
            Name = "CreateGame";

            Field<GameType>(
                "createGame",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CompanyInputType>> { Name = "game" }
                ),
                resolve: context =>
                {
                    var game = context.GetArgument<Game>("game");
                    return gameRepository.Add(game);
                });
        }
    }
}
