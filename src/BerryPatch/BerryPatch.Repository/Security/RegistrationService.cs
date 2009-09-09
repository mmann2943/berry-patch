namespace BerryPatch.Repository.Security
{
    public interface RegistrationService
    {
        void Register(SiteVisitor visitor);
        bool IsExisingFamilyMember(SiteVisitor visitor);
    }
}