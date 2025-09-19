using ClubeBeneficiosAPi.Domain.Authentication;
using ClubeBeneficiosAPi.Domain.ClubeBeneficiosAPi.Domain.Enums;

namespace ClubeBeneficios.API.Authentication
{
    public class CurrentUserInfo : ICurrentUserInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public CurrentUserInfo(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var claims = httpContext.User.Claims;
            if (claims.Any(x => x.Type == "Id"))
            {
                var id = Convert.ToInt32(claims.First(x => x.Type == "Id").Value);
                Id = id;
            }

            if (claims.Any(x => x.Type == "Email"))
            {
                Email = claims.First(x => x.Type == "Email").Value;

            }
        }
    }
}
