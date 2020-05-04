using System.Collections.Generic;
using MiniMe.Chunithm.Protocols;

namespace MiniMe.Chunithm.Comparers
{
    public class UserMusicEqualityComparer :
        IEqualityComparer<UserMusic>,
        IEqualityComparer<Data.Models.UserMusic>
    {
        #region IEqualityComparer<UserMusic>
        public bool Equals(UserMusic x, UserMusic y)
        {
            return x?.MusicId == y?.MusicId;
        }

        public int GetHashCode(UserMusic obj)
        {
            return obj?.MusicId ?? -1;
        }
        #endregion

        #region IEqualityComparer<Data.Models.UserMusic>
        public bool Equals(Data.Models.UserMusic x, Data.Models.UserMusic y)
        {
            return x?.Id == y?.Id || x?.MusicId == y?.MusicId;
        }

        public int GetHashCode(Data.Models.UserMusic obj)
        {
            return obj?.GetHashCode() ?? -1;
        }
        #endregion

        #region Singleton
        public static UserMusicEqualityComparer Instance => _instance ??= new UserMusicEqualityComparer();

        private static UserMusicEqualityComparer _instance;

        private UserMusicEqualityComparer()
        {
        }
        #endregion
    }
}
