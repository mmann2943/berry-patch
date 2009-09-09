using System.Web.Mvc;
using BerryPatch.Activity;
using BerryPatch.MVC.Models;
using BerryPatch.Repository.Activity;
using BerryPatch.Repository.Security;
using MbUnit.Framework;
using Rhino.Mocks;
using web_site.Controllers;

namespace spec_for_signing_up_for_activities
{
    [TestFixture]
    public class when_saving_activities
    {
        protected ActivityRepository activityRepository;
        protected SaveActivitiesViewModel model;
        protected SiteVisitor siteVisitor;
        protected Activities activities;

        [SetUp]
        public void context()
        {
            siteVisitor = MockRepository.GenerateStub<SiteVisitor>();
            observe();

            activities = MockRepository.GenerateStub<Activities>();
            activityRepository = MockRepository.GenerateStub<ActivityRepository>();
            activityRepository.Stub(x => x.SaveActivities(siteVisitor, activities)).Return(new ActivitySaveResult(true));

            var controller = new ActivityController(activityRepository);
            var viewResult = controller.SaveActivities(siteVisitor, activities) as ViewResult;
            model = viewResult.ViewData.Model as SaveActivitiesViewModel;
        }        

        public virtual void observe()
        {            
            siteVisitor.Stub(x => x.IsLoggedIn).Return(true);   
        }
    }
}
