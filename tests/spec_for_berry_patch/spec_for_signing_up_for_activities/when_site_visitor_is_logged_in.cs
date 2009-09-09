using BerryPatch.Activity;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_signing_up_for_activities
{
    [TestFixture]
    public class when_site_visitor_is_logged_in: when_saving_activities
    {        
        [Test]
        public void should_call_the_save_method_on_the_repository()
        {
            activityRepository.AssertWasCalled(x => x.SaveActivities(siteVisitor, activities));
        }

        [Test]
        public void should_successfuly_save_the_activities()
        {
            Assert.AreEqual(ActivitySaveResult.SuccessMessage, model.Message);
        }
    }
}
