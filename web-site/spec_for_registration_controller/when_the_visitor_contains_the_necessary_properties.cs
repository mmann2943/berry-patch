using BerryPatch.MVC.Controllers;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration_controller
{
    [TestFixture]
    public class when_the_visitor_contains_the_necessary_properties: when_the_controller_is_invoked
    {
        [Test]
        public void should_use_the_registration_repository_to_save_the_visitor()
        {
            repository.AssertWasCalled(x => x.Register(visitor));
        }
        [Test]
        public void should_navagate_to_the_index_page_on_the_site()
        {
            navigator.AssertWasCalled(x => x.Navigate(SiteView.Home));
        }
    }
}