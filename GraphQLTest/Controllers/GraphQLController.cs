using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GameData;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using GraphQLTest.Helpers;
using PlayerData.Providers;
using Type = GraphQL.Instrumentation.Type;

namespace GraphQLTest.Controllers
{


    public class GraphQLController : ApiController
    {
        private readonly Schema _schema;

        public GraphQLController(IPlayerData player, IGameDataProvider dd)
        {
            _schema = new Schema { Query = new GraphQLSchema(player, dd) };

        }

        //readonly Schema _schema = new Schema { Query = new GraphQLSchema(new PlayerData.Providers.PlayerData()) };


        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var queryToExecute = query.Query;
            var _executer = new DocumentExecuter();
            var _writer = new DocumentWriter();
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = queryToExecute;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
                _.UserContext = HttpContext.Current.User.Identity.Name;

                _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();

            }).ConfigureAwait(false);

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            var json = _writer.Write(result);

            var response = request.CreateResponse(httpResult);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return response;
        }
    }


}
