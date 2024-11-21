using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_bff.Services;

namespace web_bff.Controllers.Inbound
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUser")]
        public IActionResult Get()
        {
            return Ok(_userService.GetAllUsers());
        }

        // create a post request to save user, get idToken from request params
        [HttpPost(Name = "SaveUser")]
        public IActionResult Post([FromQuery] string idToken)
        {
            _userService.save(idToken);
            return Ok();
        }

    }
}
