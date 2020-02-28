using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eShop.API.Models
{
    public class APIContext :DbContext //: IdentityDbContext<StoreUser>
    {
        public APIContext(DbContextOptions<APIContext> dbContextOptions) : base(dbContextOptions)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }        
    }
}