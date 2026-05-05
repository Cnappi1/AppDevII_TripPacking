using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripListApp.Models;

namespace TripListApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TripListApp.Models.PackingList> PackingList { get; set; } = default!;
        public DbSet<TripListApp.Models.Item> Item { get; set; } = default!;
    }
}
