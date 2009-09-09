using System.Web.Mvc;
using BerryPatch.MVC.Controllers;
using BerryPatch.Repository;
using BerryPatch.Visitor;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration_controller
{
    [TestFixture]
    public class when_the_visitor_does_not_contain_the_necessary_properties: when_the_controller_is_invoked
    {
        private ViewResult viewResult;
        private FailureResult model;

        protected override SiteVisitor CreateSiteVisitor()
        {
            return MockRepository.GenerateStub<SiteVisitor>();           
        }
        public override void observe()
        {
            viewResult = actionResult as ViewResult;
            model = viewResult.ViewData.Model as FailureResult;
        }

        [Test]
        public void should_return_the_current_view_with_a_model_that_expresses_the_data_is_not_complete_to_perform_the_registration()
        {
            Assert.IsNotNull(model);
        }

        [Test]
        public void should_contain_a_RegistrationNotCompleteException_message()
        {
            Assert.AreEqual(RegistrationNotCompleteException.MessageText, model.Message);            
        }
    }
}
