using System.Web.Mvc;
using BerryPatch.Activity;
using BerryPatch.MVC.Models;
using BerryPatch.Repository.Activity;
using MbUnit.Framework;
using Rhino.Mocks;
using TestHelper;
using web_site;
using web_site.Controllers;

namespace spec_for_signing_up_for_activities
{
    [TestFixture]
    public class when_a_visitor_views_the_activities
    {
        private ActivityRepository repository;
        private ShowActivitiesModel model;

        [SetUp]
        public void context()
        {
            MvcApplication.InitializeContainer(new TestContainer());
            repository = MockRepository.GenerateStub<ActivityRepository>();
            repository.Stub(x => x.GetActivities()).Return(new Activities());
            var controller = new ActivityController(repository);
            
            var viewResult = controller.SelectActivities() as ViewResult;
            model = viewResult.ViewData.Model as ShowActivitiesModel;
        }

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
