using Microsoft.AspNetCore.Identity;

namespace aspCMS.Auth
{
    public class AdminUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
