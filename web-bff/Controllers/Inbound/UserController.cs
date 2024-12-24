using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using web_bff.Services;

namespace web_bff.Controllers.Inbound
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(UserService userService) : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string idToken)
        {
            await userService.SaveUserAsync(idToken);
            return Ok();
        }
    }
}
