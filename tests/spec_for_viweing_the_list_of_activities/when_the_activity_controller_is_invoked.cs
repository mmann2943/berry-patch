using BerryPatch.Activity;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_viewing_the_list_of_activities
{
    [TestFixture]
    public class when_the_activity_controller_is_invoked : when_a_visitor_views_the_activities
    {
        [Test]
        public void should_use_the_repository_to_get_the_list_of_activities()
        {
            repository.AssertWasCalled(x => x.GetActivities());
        }

        [Test]
        public void the_controller_should_push_the_activities_into_the_view_model()
        {
            Assert.IsInstanceOfType(typeof(Activities), model.ListOfActivities);
        }
    }
}
