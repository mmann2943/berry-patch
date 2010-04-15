using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using BerryPatch.Repository.Security;
using BerryPatch.MVC.Controllers;
using Rhino.Mocks;
using System.Web.Mvc;
using Services;
using BerryPatch.MVC.Models;

namespace spec_for_berry_patch.spec_for_registration
{
    [TestFixture]
    public class when_entering_identifying_information_following_a_successful_registration
    {
        protected RegistrationRepository registrationRepository;
        protected NotificationService notificationService;
        protected ActionResult actionResult;
        protected RegistrationModel registrationModel;

        [SetUp]
        public void context()
        {
            registrationRepository = Createregistrationrepository();
            notificationService = MockRepository.GenerateStub<NotificationService>();
            var controller = new RegistrationController(registrationRepository, notificationService);
            registrationModel = CreateRegistrationInformation();

            observe();
            actionResult = controller.VerifyPersonalInformation(registrationModel.RegistrationCode, registrationModel.DateOfBirth, registrationModel.ZipCode);                  
        }

        protected virtual void observe()
        {
            
        }

        protected virtual RegistrationRepository Createregistrationrepository()
        {
            return MockRepository.GenerateStub<RegistrationRepository>();
        }

        protected virtual RegistrationModel CreateRegistrationInformation()
        {
            return new RegistrationModel() { RegistrationCode="ZFR12354", DateOfBirth = new DateTime(1969, 12, 13), ZipCode = "32065" };
        }
    }    
}
