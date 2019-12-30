using Microsoft.EntityFrameworkCore;

namespace WP.WebAPI.Models {
    public class WPContext : DbContext {
        public WPContext(DbContextOptions<WPContext> options)
            : base(options) {
        }

        public DbSet<PlantModel> PlantModels { get; set;}
    }
}