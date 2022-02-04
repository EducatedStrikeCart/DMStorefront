using Microsoft.AspNetCore.Identity;
using DMStorefront.Shared.Models;

namespace DMStorefront.Server.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? StoreName { get; set; }

        public Stock? StoreStock { get; set; }

        public string? CharName { get; set; }

        public int? Money { get; set; }

        public ApplicationUser()
        {

        }
    }
}
