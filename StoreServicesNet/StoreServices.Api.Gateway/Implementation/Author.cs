namespace StoreServices.Api.Gateway.Implementation
{
    using Microsoft.Extensions.Logging;
    using StoreServices.Api.Gateway.Interfaces;
    using StoreServices.Api.Gateway.Models;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Author : IAuthor
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger logger;
        public Author(IHttpClientFactory _httpClientFactory, ILogger _logger)
        {
            this.httpClientFactory = _httpClientFactory ?? throw new ArgumentNullException(nameof(_httpClientFactory));
            this.logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task<(bool result, AuthorModel author, string errorMessage)> GetAuthor(Guid authorId)
        {
            try
            {
                var client = this.httpClientFactory.CreateClient("AuthorService");
                var response = await client.GetAsync($"Author/{authorId}");
                if (response.IsSuccessStatusCode) { 
                }
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
