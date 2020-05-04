using System;

namespace MiniMe.Core.Repositories
{
    public interface IAimeService
    {
        Guid? FindIdByCardId(int cardId);
    }
}
