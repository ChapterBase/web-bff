using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using web_bff.Services;

namespace web_bff.Controllers.Inbound
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string idToken)
        {
            await _userService.SaveUserAsync(idToken);
            return Ok();
        }
    }
}
