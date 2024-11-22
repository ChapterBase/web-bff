using System.Threading.Tasks;
using web_bff.Controllers.Outbound;

namespace web_bff.Services
{
    public class UserService
    {
        private readonly CoreServiceClient _coreServiceClient;
        private readonly JwtUtilService _jwtUtilService;

        public UserService(CoreServiceClient coreServiceClient, JwtUtilService jwtUtilService)
        {
            _coreServiceClient = coreServiceClient;
            _jwtUtilService = jwtUtilService;
        }

        public async Task SaveUserAsync(string idToken)
        {
            var userDto = _jwtUtilService.DecodeToken(idToken);

            userDto.Role = "CUSTOMER";
            await _coreServiceClient.SaveUserAsync(userDto);
        }


        public object GetAllUsers()
        {
            // Mock implementation
            return new[] { new { Id = 1, Name = "User1" }, new { Id = 2, Name = "User2" } };
        }
    }
}
