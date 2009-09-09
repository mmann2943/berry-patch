using BerryPatch.Visitor;
using BerryPath.Registration;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration
{
    [TestFixture]
    public class when_a_site_visitor_attempts_to_register
    {
        protected SiteVisitor siteVisitor;
        protected RegistrationService registrationService;
        protected RegistrationRepository registrationRepository;

        [SetUp]
        public void context()
        {
            siteVisitor = MockRepository.GenerateStub<SiteVisitor>();
            registrationService = MockRepository.GenerateStub<RegistrationService>();            
            registrationRepository = MockRepository.GenerateStub<RegistrationRepository>(registrationService);

            observe();
        }

        public virtual void observe()
        {
            registrationService.Stub(x => x.IsExisingFamilyMember(siteVisitor)).Return(true);
        }
    }
}