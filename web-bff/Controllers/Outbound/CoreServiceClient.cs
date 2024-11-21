using Newtonsoft.Json;
using System.Text;
using web_bff.Dtos;

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

        public async Task<HttpResponseMessage> SaveUserAsync(UserDto userDto)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(userDto),
                Encoding.UTF8,
                "application/json"
                );

            var response = await _httpClient.PostAsync("/User", jsonContent);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
