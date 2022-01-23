using DMStorefront.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Microsoft.Extensions.Options;
<<<<<<< HEAD
using DMStorefront.Shared;
>>>>>>> 9c9fb70 (Attempting to get DbContext to work for Items)
=======
using DMStorefront.Shared.Models.Item;
>>>>>>> 2233b00 (Continuing getting CRUD working. About to delete old NewItem page and replace with prettier Razor component.)

namespace DMStorefront.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
<<<<<<< HEAD

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

    }
<<<<<<< HEAD
}
=======
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
>>>>>>> 9c9fb70 (Attempting to get DbContext to work for Items)
=======
        public DbSet<Item> Items { get; set; }
    }
    
}
>>>>>>> ff09180 (IdentityServer is fighting with Pomelo and not letting me build the DB, so I'm going to delete and rebuild the Migrations folder and see what happens. Here's hoping.)
