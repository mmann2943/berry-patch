using System.Web.Mvc;
using BerryPatch.MVC.Controllers;
using BerryPatch.Visitor;
using BerryPath.Registration;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_registration_controller
{
    [TestFixture]
    public class when_the_controller_is_invoked
    {
        private RegistrationController controller;
        protected RegistrationRepository repository;
        protected SiteVisitor visitor;
        protected SiteNavigator navigator;
        protected ActionResult actionResult;

        [SetUp]
        public void context()
        {
            var registrationService = MockRepository.GenerateStub<RegistrationService>();
            visitor = CreateSiteVisitor();
            registrationService.Stub(x => x.IsExisingFamilyMember(visitor)).Return(true);
            repository = MockRepository.GenerateStub<RegistrationRepository>(registrationService);
            navigator = MockRepository.GenerateStub<SiteNavigator>();
            
            controller = new RegistrationController(repository, navigator);
            actionResult = controller.Save(visitor);
            observe();
        }

        protected virtual SiteVisitor CreateSiteVisitor()
        {
            var siteVisitor = MockRepository.GenerateStub<SiteVisitor>();
            siteVisitor.Stub(x => x.IsLoggedIn).Return(true);
            siteVisitor.Stub(x => x.FirstName).Return("Michael");
            siteVisitor.Stub(x => x.LastName).Return("Mann");
            siteVisitor.Stub(x => x.EmailAddress).Return("mmann2943@gmail.com");

            return siteVisitor;
        }

        public virtual void observe()
        {
            
        }
    }
}