using System.Collections.Generic;
using System.Linq;
using NuclearFamily.Security;

namespace NuclearFamily.DataProvider
{
    public class EmbeddedSqlUserRepository: IUserRepository
    {
        public IUser GetUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public List<IUser> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public List<IUser> GetUsers(IQueryable<IUser> selectionCriteria)
        {
            throw new System.NotImplementedException();
        }
    }
}