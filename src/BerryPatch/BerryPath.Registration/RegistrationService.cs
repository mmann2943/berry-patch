using BerryPatch.Visitor;

namespace BerryPath.Registration
{
    public interface RegistrationService
    {
        void Register(SiteVisitor visitor);
        bool IsExisingFamilyMember(SiteVisitor visitor);
    }
}