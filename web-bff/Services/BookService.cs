using web_bff.Controllers.Outbound;
using ChapterBaseAPI.Dtos;
using web_bff.Dtos;

namespace web_bff.Services
{
    public class BookService(CoreServiceClient coreServiceClient)
    {

        public async Task<ResponseDto<object>> Search(string query)
        {
            try
            {
                return await coreServiceClient.Search(query);
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "An error occurred while retrieving books: " + ex.Message
                };
            }
        }


        public async Task<ResponseDto<object>> FindAllBooks(RequestDto request)
        {
            try
            {
                return await coreServiceClient.FindAllBooksAsync(request);
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "An error occurred while retrieving books: " + ex.Message
                };
            }
        }

        public async Task<ResponseDto<BookDto>> FindBookById(Guid id)
        {
            try
            {
                return await coreServiceClient.FindBookByIdAsync(id);
            }
            catch (Exception ex)
            {
                return new ResponseDto<BookDto>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the book: " + ex.Message
                };
            }
        }

      
    }
}
