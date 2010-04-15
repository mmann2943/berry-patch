using BerryPatch.Repository.Security;
using MbUnit.Framework;
using Rhino.Mocks;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;
using Services;

namespace spec_for_registration
{
    [TestFixture]
    public class when_a_site_visitor_attempts_to_register
    {        
        protected RegistrationRepository registrationRepository;
        protected NotificationService notificationService;        
        protected const string RegistrationCode = "H23456";
        protected ActionResult actionResult;

        [SetUp]
        public void context()
        {     
            registrationRepository = MockRepository.GenerateStub<RegistrationRepository>();
            notificationService = MockRepository.GenerateStub<NotificationService>();

            var controller = new RegistrationController(registrationRepository, notificationService);

            observe();

            actionResult = controller.EnterRegCode(RegistrationCode);                       
        }

        public virtual void observe()
        {
            
        }
    }
}