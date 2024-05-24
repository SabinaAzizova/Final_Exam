using Microsoft.AspNetCore.Identity;

namespace Bilet_12.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
