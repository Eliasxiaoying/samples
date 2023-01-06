using Microsoft.AspNetCore.Http;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_WebSocketSample.Middlewares;

public class WebSocketHandler
{
    private readonly RequestDelegate _next;

    public WebSocketHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await Handle(webSocket);
        }
        await _next(context);
    }

    private async Task Handle(WebSocket webSocket)
    {
        var buffer = new byte[1024];
        var request = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!request.CloseStatus.HasValue)
        {
            var requestMessage = Encoding.UTF8.GetString(buffer);
            Console.WriteLine(requestMessage);
            var responseMessage = requestMessage + DateTime.Now;
            Console.WriteLine(responseMessage);

            var responseBuffer = Encoding.UTF8.GetBytes(responseMessage);
            await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), request.MessageType, request.EndOfMessage, CancellationToken.None);

            request = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
    }
}