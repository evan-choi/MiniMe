using Microsoft.EntityFrameworkCore;
using MiniMe.Core.Data.Models;

namespace MiniMe.Core.Data
{
    public class MiniMeContext : DbContext
    {
        public DbSet<AimeUser> AimeUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("minime.db")}");
        }

        public static void Initialize()
        {
            using var context = new MiniMeContext();
            context.Database.Migrate();
        }
    }
}
