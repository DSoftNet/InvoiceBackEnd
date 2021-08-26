using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using System.IO;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                await LogRequest(context);
                await LogResponse(context);
            }
            else
            {
                await _next(context);
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();

            await using MemoryStream requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);

            _logger.LogInformation("Request, {Schema}, {Host}, {RequestPath}, {QueryString}, {Body}",
                context.Request.Scheme,
                context.Request.Host,
                context.Request.Path,
                context.Request.QueryString,
                ReadStreamInChunks(requestStream));

            context.Request.Body.Position = 0;
        }

        /// <summary>
        /// Convert to string information received on stream
        /// </summary>
        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;

            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;

            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                    0,
                    readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }

        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            await using MemoryStream responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation("Response, {Schema}, {Host}, {RequestPath}, {QueryString}, {Body}",
                context.Request.Scheme,
                context.Request.Host,
                context.Request.Path,
                context.Request.QueryString,
                text);

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}