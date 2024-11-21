using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace web_bff.Controllers.Outbound
{
    public class CoreServiceClient
    {
        private readonly HttpClient _httpClient;

        public CoreServiceClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Get base URL from appsettings.json
            var baseUrl = configuration["CoreService:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("CoreService:BaseUrl configuration is missing.");
            }

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<HttpResponseMessage> SaveUserAsync(string idToken)
        {
            var queryParams = $"?idToken={Uri.EscapeDataString(idToken)}";
            var response = await _httpClient.PostAsync($"User{queryParams}", null);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to call Core Service SaveUser API. Status Code: {response.StatusCode}");
            }

            return response;
        }
    }
}
