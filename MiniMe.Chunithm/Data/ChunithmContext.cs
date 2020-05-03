using Microsoft.EntityFrameworkCore;
using MiniMe.Chunithm.Data.Models;
using MiniMe.Core;

namespace MiniMe.Chunithm.Data
{
    public class ChunithmContext : DbContext
    {
        public DbSet<UserActivity> Activities { get; set; }

        public DbSet<UserCharacter> Characters { get; set; }

        public DbSet<UserCourse> Courses { get; set; }

        public DbSet<UserData> Datas { get; set; }

        public DbSet<UserDataEx> DataExs { get; set; }

        public DbSet<UserDuelList> DuelLists { get; set; }

        public DbSet<UserGameOption> GameOptions { get; set; }

        public DbSet<UserGameOptionEx> GameOptionExs { get; set; }

        public DbSet<UserItem> Items { get; set; }

        public DbSet<UserMap> Maps { get; set; }

        public DbSet<UserMusic> Musics { get; set; }

        public DbSet<UserPlayLog> Paylogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("chunithm.db")}");
        }
    }
}
