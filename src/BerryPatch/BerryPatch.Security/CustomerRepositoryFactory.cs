using BerryPatch.Config;
using BerryPatch.Security;

namespace BerryPatch.Security
{
    public class CustomerRepositoryFactory: UserRepositoryFactory
    {
        private IConfig _config;
        public CustomerRepositoryFactory(IConfig config)
        {
            _config = config;
        }

        public override IUserRepository Create(string userName, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}