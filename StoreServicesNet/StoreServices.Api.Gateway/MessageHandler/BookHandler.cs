namespace StoreServices.Api.Gateway.MessageHandler
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class BookHandler : DelegatingHandler
    {
        private readonly ILogger<BookHandler> logger;

        public BookHandler(ILogger<BookHandler> _logger)
        {
            this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.logger.LogInformation($"Inicia el request");
            return base.SendAsync(request, cancellationToken);
        }
    }
}