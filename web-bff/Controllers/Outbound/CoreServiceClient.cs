using ChapterBaseAPI.Dtos;
using RestSharp;
using web_bff.Dtos;

namespace web_bff.Controllers.Outbound
{
    public class CoreServiceClient
    {
        private readonly RestClient _restClient;

        public CoreServiceClient(IConfiguration configuration)
        {
            
            var baseUrl = configuration["CoreService:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("CoreService:BaseUrl configuration is missing.");
            }

            _restClient = new RestClient(baseUrl);
        }

        // User
        public async Task<ResponseDto<object>> SaveUserAsync(UserDto userDto)
        {
            var request = new RestRequest("/User", Method.Post);
            request.AddJsonBody(userDto);

            return await ExecuteRequestAsync<ResponseDto<object>>(request);
        }

        // Book
        public async Task<ResponseDto<object>> Search(string query)
        {

            var request = new RestRequest("/Book/Search", Method.Get);
            request.AddQueryParameter("query", query);

            return await ExecuteRequestAsync<ResponseDto<object>>(request);
        }

        public async Task<ResponseDto<object>> FindAllBooksAsync(RequestDto request)
        {
            var restRequest = new RestRequest("/Book/All", Method.Post);
            restRequest.AddJsonBody(request);

            return await ExecuteRequestAsync<ResponseDto<object>>(restRequest);
        }


        public async Task<ResponseDto<BookDto>> FindBookByIdAsync(Guid id)
        {
            var request = new RestRequest($"/Book/{id}", Method.Get);

            return await ExecuteRequestAsync<ResponseDto<BookDto>>(request);
        }

       
        private async Task<T> ExecuteRequestAsync<T>(RestRequest request) where T : class
        {
            var response = await _restClient.ExecuteAsync<T>(request);
            if (!response.IsSuccessful || response.Data == null)
            {
                throw new Exception($"Request failed. StatusCode: {response.StatusCode}, Message: {response.ErrorMessage}");
            }

            return response.Data;
        }


        
    }
}
