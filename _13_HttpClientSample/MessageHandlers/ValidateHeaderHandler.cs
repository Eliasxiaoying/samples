using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _13_HttpClientSample.MessageHandlers;

public class ValidateHeaderHandler : DelegatingHandler
{
    /// <summary>
    /// 拦截用户发出的Http请求，并执行额外的行为
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.Headers.Contains("User-Token"))
        {
            request.Headers.Add("User-Token", "hah");
        }

        if (request.Headers.Contains("abc"))
        {
            var response = new HttpResponseMessage(HttpStatusCode.Ambiguous);
            return Task.FromResult(response);
        }
        return base.SendAsync(request, cancellationToken);
    }
}