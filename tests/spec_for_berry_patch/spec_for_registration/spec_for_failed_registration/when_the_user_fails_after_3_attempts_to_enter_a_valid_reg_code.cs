using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using spec_for_registration;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;

namespace spec_for_berry_patch.spec_for_registration
{
    [TestFixture]
    public class when_the_user_exceeds_the_maximum_attempts_to_enter_a_valid_reg_code : when_a_site_visitor_attempts_to_register
    {
        public override void observe()
        {
            registrationRepository.Stub(x => x.NumberOfTimesRegCodeEnteredToday(RegistrationCode)).Return(RegistrationController.MaximumNumberOfTimesToEnterRegCode + 1);
        }

        [Test]
        public void should_navigate_to_the_page_to_notify_the_user_the_reg_code_has_been_deactivated()
        {
            Assert.AreEqual(SiteView.RegistrationCodeIsDisabled, ((ViewResult)actionResult).ViewName);
        }

        [Test]
        public void should_deactivate_the_registration_code()
        {
            registrationRepository.AssertWasCalled(x => x.DeactivateRegCode(RegistrationCode));
        }

        [Test]
        public void should_notify_the_administrator_of_the_site_that_the_reg_code_was_deactivated()
        {
            notificationService.AssertWasCalled(x => x.NotifyAdminRegCodeWasDeactivated(RegistrationCode));
        }
    }
}
