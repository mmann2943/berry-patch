namespace BerryPatch.Repository.Security
{
    public class RegistrationRepository
    {
        private readonly RegistrationService registrationService;

        public RegistrationRepository(RegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public virtual void Register(SiteVisitor visitor)
        {
            if (!registrationService.IsExisingFamilyMember(visitor))
                throw new NonExistingFamilyMemberException();

            registrationService.Register(visitor);
        }
    }
}