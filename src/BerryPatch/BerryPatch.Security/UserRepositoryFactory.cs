namespace BerryPatch.Security
{
    public abstract class UserRepositoryFactory
    {
        public abstract IUserRepository Create(string userName, string password);
    }
}