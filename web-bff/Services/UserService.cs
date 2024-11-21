using System.Threading.Tasks;
using web_bff.Controllers.Outbound;

namespace web_bff.Services
{
    public class UserService
    {
        private readonly CoreServiceClient _coreServiceClient;

        public UserService(CoreServiceClient coreServiceClient)
        {
            _coreServiceClient = coreServiceClient;
        }

        public async Task SaveUserAsync(string idToken)
        {
            await _coreServiceClient.SaveUserAsync(idToken);
        }

        public object GetAllUsers()
        {
            // Mock implementation
            return new[] { new { Id = 1, Name = "User1" }, new { Id = 2, Name = "User2" } };
        }
    }
}
