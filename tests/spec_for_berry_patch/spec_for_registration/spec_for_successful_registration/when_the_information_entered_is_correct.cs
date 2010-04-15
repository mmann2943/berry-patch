using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;

namespace spec_for_berry_patch.spec_for_registration.spec_for_successful_registration
{
    [TestFixture]
    public class when_the_information_entered_is_correct: when_entering_identifying_information_following_a_successful_registration
    {
        protected override void observe()
        {
            registrationRepository.Stub(x => x.PersonalInformationIsValid(registrationModel.RegistrationCode, registrationModel.DateOfBirth, registrationModel.ZipCode)).Return(true);
        }

        [Test]
        public void should_navigate_to_the_successful_registration_page()
        {
            Assert.AreEqual(SiteView.RegistrationSuccess, ((ViewResult)actionResult).ViewName);
        }

        [Test]
        public void should_email_the_user_a_temporary_salted_password_that_will_log_them_in()
        {
            notificationService.AssertWasCalled(x => x.NotifyUserOfSucessfullRegistration(Arg.Is(registrationModel.RegistrationCode), Arg.Is(registrationModel.DateOfBirth), Arg.Is(registrationModel.ZipCode)));
        }
    }
}
