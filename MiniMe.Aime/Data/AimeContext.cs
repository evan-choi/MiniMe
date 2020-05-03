using Microsoft.EntityFrameworkCore;
using MiniMe.Aime.Data.Models;
using MiniMe.Core;

namespace MiniMe.Aime.Data
{
    public sealed class AimeContext : DbContext
    {
        public DbSet<AimeUser> AimeUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("aime.db")}");
        }
    }
}
