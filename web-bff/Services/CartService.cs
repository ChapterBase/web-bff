
using ChapterBaseAPI.Dtos;
using web_bff.Controllers.Outbound;

namespace web_bff.Services
{
    public class CartService(CoreServiceClient coreServiceClient)
    {
        public async Task<ResponseDto<string>> Add(Guid userId, Guid bookId, int qty)
        {
            try
            {
                await coreServiceClient.AddToCartAsync(userId, bookId, qty);
                return new ResponseDto<string>
                {
                    Success = true,
                    Message = "Cart updated successfully"
                }; 
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>
                {
                    Success = false,
                    Message = "An error occurred while retrieving books: " + ex.Message
                };
            }
        }
    }
}
