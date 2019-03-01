using GraphQL.Types;

namespace gql.api.models
{
    public class CompanyInputType : InputObjectGraphType
    {
        public CompanyInputType()
        {
            Name = "CompanyInput";
            Field<IntGraphType>("Id");
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<StringGraphType>("Country");
           
        }
    }
}