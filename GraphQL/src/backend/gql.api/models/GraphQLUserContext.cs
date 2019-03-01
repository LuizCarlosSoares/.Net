using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.X509Certificates;
using GraphQL.Introspection;


namespace gql.api.models {
    public class GraphQLUserContext
    {
        private readonly IHostingEnvironment _env;

        public GraphQLUserContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public bool IsProduction() => _env.IsProduction();
    }
}
