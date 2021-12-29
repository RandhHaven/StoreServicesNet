namespace StoreServices.Api.ShoppingCart.Services.BookService
{
    using Microsoft.Extensions.Logging;
    using StoreServices.Api.ShoppingCart.Services.RemoteModels;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<(bool result, RemoteBook book, String ErrorMessage)> GetBook(Guid BookID)
        {
            try
            {
                var client = _httpClient.CreateClient("Book");
                var response = await client.GetAsync($"api/Book/{ BookID }");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteBook>(contenido, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}