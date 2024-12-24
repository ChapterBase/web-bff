using web_bff.Dtos;
using web_bff.Services;
using Microsoft.AspNetCore.Mvc;

namespace web_bff.Controllers.Inbound
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(BookService bookService) : Controller
    {
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var response = await bookService.Search(query);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

       

        [HttpPost("All")]
        public async Task<IActionResult> FindAll([FromBody] RequestDto request)
        {
            var response = await bookService.FindAllBooks(request);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            var response = await bookService.FindBookById(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

       
    }
}
