using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Filters;

namespace GraphQLTest.Auth
{
    public class AuthAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return;
            }

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                if (authHeader.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase) &&
                !String.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    var sessionId = authHeader.Parameter;
                    if (!String.IsNullOrEmpty(sessionId))
                    {
                        var principal = new GenericPrincipal(new GenericIdentity(sessionId), null);
                        HttpContext.Current.User = principal;
                        return;
                    }
                }
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}