using Microsoft.AspNetCore.Identity;

namespace papaute.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
    }
}