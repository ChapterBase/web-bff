using Microsoft.AspNetCore.Mvc;
using web_bff.Services;

namespace web_bff.Controllers.Inbound
{
    [ApiController]
    [Route("[controller]")]
    public class CartController(CartService cartService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] Guid userId, [FromQuery] Guid bookId, [FromQuery] int qty)
        {
            var response = await cartService.Add(userId, bookId, qty);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
