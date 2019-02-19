using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gql.api.models
{
    public class CompanySchema : Schema
    {
        public CompanySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CompanyQuery>();
            Mutation = resolver.Resolve<CompanyMutation>();
        }
    }
}
