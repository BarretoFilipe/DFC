using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User : IdentityUser
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null;
    }
}