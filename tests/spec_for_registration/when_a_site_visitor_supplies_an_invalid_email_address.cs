using BerryPatch.Exceptions;
using BerryPatch.Visitor;
using BerryPatch.Web;
using BerryPath.Registration;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration
{
    [TestFixture]
    public class when_a_site_visitor_attempts_to_register_but_does_not_exist_in_the_repository
    {
        private SiteVisitor siteVisitor;
        private RegistrationService registrationService;
        private RegistrationRepository registrationRepository;

        [SetUp]
        public void context()
        {
            siteVisitor = MockRepository.GenerateStub<SiteVisitor>();
            registrationService = MockRepository.GenerateStub<RegistrationService>();
            registrationService.Stub(x => x.IsExisingFamilyMember(siteVisitor)).Return(false);
            registrationRepository = MockRepository.GenerateStub<RegistrationRepository>(registrationService);

        }

        [Test, ExpectedException(typeof(NonExistingFamilyMemberException))]
        public void should_notify_the_site_visitor_that_they_are_not_recognized()
        {
            registrationRepository.Register(siteVisitor);
        }
    }
}
