using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Validation;

namespace gql.api.models
{
    public class IntrospectionNotAllowed : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
                var myContext = context.UserContext as GraphQLUserContext;
                if (!myContext.IsProduction())
                {
                    //return;
                }

                _.Match<GraphQL.Language.AST.Field>(
                    enter: field =>
                    {
                            // don't recall the exact properties off-hand
                            if (field.Name.Equals("__schema"))
                        {
                            var error = new ValidationError(
                                context.OriginalQuery,
                                "code1",
                                "Not allowed",
                                field);
                            context.ReportError(error);
                        }
                    });
            });
        }
    }
}