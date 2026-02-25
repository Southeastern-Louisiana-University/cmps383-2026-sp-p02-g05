using Microsoft.AspNetCore.Identity;

namespace Selu383.SP26.Api.Features.User
{

    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> Roles { get; set; } = null!;
    }

}