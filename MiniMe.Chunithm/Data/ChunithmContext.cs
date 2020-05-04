using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MiniMe.Chunithm.Data.Models;
using MiniMe.Core;
using Serilog.Extensions.Logging;

namespace MiniMe.Chunithm.Data
{
    public class ChunithmContext : DbContext
    {
        public DbSet<UserProfile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("chunithm.db")}");
            //options.UseLoggerFactory(new SerilogLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDataEx>(builder =>
            {
                builder
                    .HasOne(data => data.Profile)
                    .WithOne(profile => profile.DataEx)
                    .HasForeignKey<UserDataEx>(data => data.Id);

                builder
                    .HasIndex(e => e.Id)
                    .IsUnique();
            });

            modelBuilder.Entity<UserGameOption>(builder =>
            {
                builder
                    .HasOne(option => option.Profile)
                    .WithOne(profile => profile.GameOption)
                    .HasForeignKey<UserGameOption>(option => option.Id);

                builder
                    .HasIndex(e => e.Id)
                    .IsUnique();
            });

            modelBuilder.Entity<UserGameOptionEx>(builder =>
            {
                builder
                    .HasOne(optionEx => optionEx.Profile)
                    .WithOne(profile => profile.GameOptionEx)
                    .HasForeignKey<UserGameOptionEx>(optionEx => optionEx.Id);

                builder
                    .HasIndex(e => e.Id)
                    .IsUnique();
            });

            modelBuilder.Entity<UserActivity>(builder =>
            {
                builder.HasOne(activity => activity.Profile)
                    .WithMany(profile => profile.Activities)
                    .HasForeignKey(activity => activity.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.Kind, e.ActivityId })
                    .IsUnique();
            });

            modelBuilder.Entity<UserCharacter>(builder =>
            {
                builder.HasOne(character => character.Profile)
                    .WithMany(profile => profile.Characters)
                    .HasForeignKey(character => character.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.CharacterId })
                    .IsUnique();
            });

            modelBuilder.Entity<UserCourse>(builder =>
            {
                builder.HasOne(course => course.Profile)
                    .WithMany(profile => profile.Courses)
                    .HasForeignKey(course => course.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.CourseId })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDuelList>(builder =>
            {
                builder.HasOne(duelList => duelList.Profile)
                    .WithMany(userProfile => userProfile.DuelLists)
                    .HasForeignKey(duelList => duelList.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.DuelId })
                    .IsUnique();
            });

            modelBuilder.Entity<UserItem>(builder =>
            {
                builder.HasOne(item => item.Profile)
                    .WithMany(profile => profile.Items)
                    .HasForeignKey(item => item.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.ItemId, e.ItemKind })
                    .IsUnique();
            });

            modelBuilder.Entity<UserMap>(builder =>
            {
                builder.HasOne(map => map.Profile)
                    .WithMany(profile => profile.Maps)
                    .HasForeignKey(map => map.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.MapId })
                    .IsUnique();
            });

            modelBuilder.Entity<UserMusic>(builder =>
            {
                builder.HasOne(music => music.Profile)
                    .WithMany(profile => profile.Musics)
                    .HasForeignKey(music => music.ProfileId);

                builder
                    .HasIndex(e => new { e.ProfileId, e.MusicId, e.Level })
                    .IsUnique();
            });

            modelBuilder.Entity<UserPlayLog>()
                .HasOne(log => log.Profile)
                .WithMany(profile => profile.PlayLogs)
                .HasForeignKey(plog => plog.ProfileId);
        }

        public UserProfile FindProfile([AllowNull] Guid? aimeId)
        {
            return FindProfileWithQuery(aimeId, null);
        }

        public UserProfile FindProfileWithAllData([AllowNull] Guid? aimeId)
        {
            return FindProfileWithQuery(aimeId, ps => ps
                .Include(p => p.DataEx)
                .Include(p => p.GameOption)
                .Include(p => p.GameOptionEx)
                .Include(p => p.Activities)
                .Include(p => p.Characters)
                .Include(p => p.Courses)
                .Include(p => p.DuelLists)
                .Include(p => p.Items)
                .Include(p => p.Maps)
                .Include(p => p.Musics)
                .Include(p => p.PlayLogs));
        }

        public UserProfile FindProfileWithData<T>(
            [AllowNull] Guid? aimeId,
            [NotNull] Expression<Func<UserProfile, T>> include)
        {
            return FindProfileWithQuery(aimeId, ps => ps.Include(include));
        }

        public UserProfile FindProfileWithQuery(
            [AllowNull] Guid? aimeId,
            [AllowNull] Func<IQueryable<UserProfile>, IQueryable<UserProfile>> wrapper)
        {
            if (!aimeId.HasValue)
                return null;

            return (wrapper == null ? Profiles : wrapper(Profiles))
                .SingleOrDefault(d => d.AimeId == aimeId);
        }
    }
}
