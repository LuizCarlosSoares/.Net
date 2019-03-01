using GraphQL.Types;

namespace gql.api.models
{
    public class GameInputType : InputObjectGraphType
    {
        public GameInputType()
        {
            Name = "GameInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<DateTimeGraphType>("releaseDate");
            Field<CompanyInputType>("developer");
            Field<CompanyInputType>("publiser");
           
        }
    }
}