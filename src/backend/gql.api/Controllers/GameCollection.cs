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
    public class GameCollection : ControllerBase
    {
        private readonly IDocumentExecuter documentExecuter;
        private readonly ISchema schema;
        private readonly GraphQLUserContext userContext;
        public GameCollection(ISchema schema, IDocumentExecuter documentExecuter, GraphQLUserContext userContext)
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


            // TEST 1 START -- Disable Introspection
            //var documentBuilder = new GraphQL.Execution.GraphQLDocumentBuilder();
            //var document = documentBuilder.Build(executionOptions.Query);

            //foreach (var documentOperation in document.Operations)
            //{
            //    var selectionSet = documentOperation.SelectionSet;
            //    foreach (var selection in selectionSet.Selections)
            //    {
            //        var field = selection as GraphQL.Language.AST.Field;
            //        if (field != null)
            //        {
            //            if (field.Name.Equals("__schema"))
            //            {
            //                return StatusCode(403); //Forbid()
            //            }
            //        }
            //    }
            //}

            //_schema.Execute(_ =>
            //{
            //    _.Query = executionOptions.Query;
            //    _.Document = document;
            //});
            // TEST 1 END -- Disable Introspection



            // TEST 2 STRT -- Query Validation
            //var tresult = await _schema.ExecuteAsync(_ =>
            //{
            //    _.Query = executionOptions.Query;
            //    _.ValidationRules = new[] {new IntrospectionNotAllowed()}.Concat(DocumentValidator.CoreRules());
            //    _.Document = new GraphQL.Execution.GraphQLDocumentBuilder().Build(executionOptions.Query);
            //    _.UserContext = _userContext;
            //});
            // TEST 2 END -- Query Validation


            var result = await documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
