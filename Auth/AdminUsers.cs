using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace aspCMS.Auth
{
    public class AdminUsers : IdentityUser
    {
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
