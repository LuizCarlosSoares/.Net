using GraphQL.Types;

namespace gql.api.models
{
    public class CompanyInputType : InputObjectGraphType
    {
        public CompanyInputType()
        {
            Name = "CompanyInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("county");
           
        }
    }
}