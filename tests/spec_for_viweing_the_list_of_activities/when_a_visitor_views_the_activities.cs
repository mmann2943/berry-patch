using System.Web.Mvc;
using BerryPatch.Activity;
using BerryPatch.MVC.Models;
using BerryPatch.Visitor;
using MbUnit.Framework;
using Rhino.Mocks;
using web_site.Controllers;

namespace spec_for_viewing_the_list_of_activities
{
    [TestFixture]
    public class when_a_visitor_views_the_activities
    {
        protected ActivityRepository repository;
        protected ShowActivitiesModel model;

        [SetUp]
        public void context()
        {
            repository = MockRepository.GenerateStub<ActivityRepository>();
            repository.Stub(x => x.GetActivities()).Return(new Activities());
            var controller = new ActivityController(repository);

            var visitor = MockRepository.GenerateStub<SiteVisitor>();            
            var viewResult = controller.ShowActivities(visitor) as ViewResult;
            model = viewResult.ViewData.Model as ShowActivitiesModel;
        }

        public virtual void observe()
        {
        }
    }
}