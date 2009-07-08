using MbUnit.Framework;

namespace spec_for_viewing_the_list_of_activities
{
    [TestFixture]
    public class when_the_visitor_is_not_logged_in:when_a_visitor_views_the_activities
    {
        [Test]
        public void the_view_model_should_inform_the_view_to_not_display_the_save_button()
        {
            Assert.IsFalse(model.ShowSaveButton);
        }
    }
}
