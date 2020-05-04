using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MiniMe.Aime.Data.Models;
using MiniMe.Core;
using MiniMe.Core.Repositories;

namespace MiniMe.Aime.Data
{
    public sealed class AimeContext : DbContext, IAimeService
    {
        public DbSet<AimeUser> AimeUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={MiniMeEnvironment.GetDataFile("aime.db")}");
        }

        public void Add(AimeUser user)
        {
            AimeUsers.Add(user);
            SaveChanges();
        }

        public AimeUser Find(Expression<Func<AimeUser, bool>> expression)
        {
            var user = AimeUsers.FirstOrDefault(expression);

            if (user != null)
            {
                user.AccessAt = DateTimeOffset.Now;
                SaveChanges();
            }

            return user;
        }

        #region IAimeService
        private readonly ConcurrentDictionary<int, Guid?> _idCache = new ConcurrentDictionary<int, Guid?>();

        Guid? IAimeService.FindIdByCardId(int cardId)
        {
            if (!_idCache.TryGetValue(cardId, out Guid? aimeId))
            {
                aimeId = AimeUsers
                    .AsNoTracking()
                    .FirstOrDefault(u => u.CardId == cardId)?.Id;

                _idCache[cardId] = aimeId;
            }

            return aimeId;
        }
        #endregion
    }
}
