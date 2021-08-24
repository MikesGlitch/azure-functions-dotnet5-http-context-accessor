using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace HttpContextAccessor
{
    public class Function1
    {
        public Function1(IHttpContextAccessor accessor)
        {
            Accessor = accessor;
        }

        public IHttpContextAccessor Accessor { get; }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, FunctionContext executionContext)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(Accessor.HttpContext == null ? "HttpContext is null" : "We have HTTP Context!");

            return response;
        }
    }
}
