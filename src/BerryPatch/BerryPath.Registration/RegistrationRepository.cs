using BerryPatch.Exceptions;
using BerryPatch.Visitor;

namespace BerryPath.Registration
{
    public class RegistrationRepository
    {
        private readonly RegistrationService registrationService;

        public RegistrationRepository(RegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public void Register(SiteVisitor visitor)
        {
            if (!registrationService.IsExisingFamilyMember(visitor))
                throw new NonExistingFamilyMemberException();

            registrationService.Register(visitor);
        }
    }
}