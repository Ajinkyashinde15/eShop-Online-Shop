using Microsoft.AspNetCore.Identity;

namespace eShop.API.Models.Entities
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}