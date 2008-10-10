using System.Collections.Generic;
using System.Linq;

namespace BerryPatch.Security
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user based on their unique identifier.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        IUser GetUser(string userId);

        /// <summary>
        /// Gets all the users.
        /// </summary>
        /// <returns></returns>
        List<IUser> GetUsers();

        /// <summary>
        /// Gets the users based on the selection criteria passed in.
        /// </summary>
        /// <param name="selectionCriteria">The selection criteria.</param>
        /// <returns></returns>
        List<IUser> GetUsers(IQueryable<IUser> selectionCriteria);
    }
}