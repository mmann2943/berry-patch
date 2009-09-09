using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration
{
    [TestFixture]
    public class when_a_site_visitor_exists_in_the_repository: when_a_site_visitor_attempts_to_register
    {
        public override void observe()
        {
            base.observe();
            registrationRepository.Register(siteVisitor);
        }
        [Test]
        public void should_call_the_registration_service_to_register_the_visitor()
        {
            registrationService.AssertWasCalled(x => x.Register(siteVisitor));
        }
    }
}
