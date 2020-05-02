using System;
using System.Linq;
using System.Linq.Expressions;
using MiniMe.Core.Data;
using MiniMe.Core.Data.Models;

namespace MiniMe.Aime.Data
{
    public class AimeUserRepository : IDisposable
    {
        private readonly MiniMeContext _context;

        public AimeUserRepository()
        {
            _context = new MiniMeContext();
        }

        public void Add(AimeUser user)
        {
            _context.AimeUsers.Add(user);
            _context.SaveChanges();
        }

        public AimeUser Find(Expression<Func<AimeUser, bool>> expression)
        {
            var user = _context.AimeUsers.FirstOrDefault(expression);

            if (user != null)
            {
                user.AccessAt = DateTimeOffset.Now;
                _context.SaveChanges();
            }

            return user;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
