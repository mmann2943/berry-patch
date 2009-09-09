using BerryPatch.Exceptions;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration
{
    [TestFixture]
    public class when_a_site_visitor_does_not_exist_in_the_repository: when_a_site_visitor_attempts_to_register
    {
        public override void observe()
        {
            registrationService.Stub(x => x.IsExisingFamilyMember(siteVisitor)).Return(false);
        }
        [Test, ExpectedException(typeof(NonExistingFamilyMemberException))]
        public void should_notify_the_site_visitor_that_they_are_not_recognized()
        {
            registrationRepository.Register(siteVisitor);
        }
    }
}
