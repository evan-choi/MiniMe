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

        public DbSet<UserDataExt> DataExts { get; set; }

        public DbSet<UserDuelList> DuelLists { get; set; }

        public DbSet<UserGameOption> GameOptions { get; set; }

        public DbSet<UserGameOptionExt> GameOptionExts { get; set; }

        public DbSet<UserItem> Items { get; set; }

        public DbSet<UserMap> Maps { get; set; }

        public DbSet<UserMusic> Musics { get; set; }

        public DbSet<UserPaylog> Paylogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("chunithm.db")}");
        }
    }
}
