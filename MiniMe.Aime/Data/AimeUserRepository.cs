using System;
using System.Linq;
using System.Linq.Expressions;
using MiniMe.Aime.Data.Models;

namespace MiniMe.Aime.Data
{
    internal sealed class AimeUserRepository
    {
        private readonly AimeContext _context;

        public AimeUserRepository(AimeContext context)
        {
            _context = context;
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
    }
}
