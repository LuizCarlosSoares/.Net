using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gql.api.models;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Mvc;

namespace gql.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCollectionController : ControllerBase
    {
        private readonly IDocumentExecuter documentExecuter;
        private readonly ISchema schema;
        private readonly GraphQLUserContext userContext;
        public GameCollectionController(ISchema schema, IDocumentExecuter documentExecuter, GraphQLUserContext userContext)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
            this.userContext = userContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs,
                UserContext = userContext,
                ValidationRules = new[] { new IntrospectionNotAllowed() }.Concat(DocumentValidator.CoreRules())
            };          


            var result = await documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }      
    }
}
