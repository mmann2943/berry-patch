using BerryPatch.Repository.Security;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_signing_up_for_activities
{
    [TestFixture]
    public class when_site_visitor_is_not_logged_in: when_saving_activities
    {
        public override void  observe()
        {
 	        siteVisitor.Stub(x => x.IsLoggedIn).Return(false);
        }

        [Test]
        public void should_show_the_login_control()
        {
            Assert.IsTrue(model.ShowLoginContol);
        }

        [Test]
        public void should_present_the_error_message_stating_loggin_information_is_required_before_saving_the_activities()
        {
            Assert.AreEqual(SiteVisitorNotLoggedInException.ErrorMessage, model.Message);
        }
    }
}