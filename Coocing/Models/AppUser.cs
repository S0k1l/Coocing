using Microsoft.AspNetCore.Identity;

namespace Coocing.Models
{
    public class AppUser: IdentityUser
    {
        ICollection<UserCourses> UserCourses { get; set; }
        ICollection<Coments> Coments { get; set; }

    }
}
