
using web_bff.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace web_bff.Services
{
    public class JwtUtilService
    {
        public UserDto DecodeToken(string idToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(idToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new UnauthorizedAccessException("Id Token is null. Try with token");
            }

            var UserName = jsonToken.Claims.First(claim => claim.Type == "cognito:username").Value;
            var Email = jsonToken.Claims.First(claim => claim.Type == "email").Value;
            
            return new UserDto
            {
                Username = UserName,
                Email = Email

            };
        }
    }
}
