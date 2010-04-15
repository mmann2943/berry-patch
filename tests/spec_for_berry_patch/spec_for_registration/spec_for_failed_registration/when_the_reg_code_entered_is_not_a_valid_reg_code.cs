using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;
using spec_for_registration;

namespace spec_for_berry_patch.spec_for_registration
{
    public class when_the_reg_code_entered_is_not_a_valid_reg_code : when_a_site_visitor_attempts_to_register
    {
        public override void observe()
        {
            registrationRepository.Stub(x => x.IsValidRegCode(RegistrationCode)).Return(false);
        }

        [Test]
        public void should_navigate_to_the_page_where_the_user_enters_the_reg_code()
        {
            Assert.AreEqual(SiteView.EnterRegistrationCode, ((ViewResult)actionResult).ViewName);
        }

        [Test]
        public void should_have_a_message_to_display_present_in_the_view_data()
        {
            Assert.AreEqual(MessagesToDisplay.InvalidRegCodeMessage, ((ViewResult)actionResult).ViewData.First().Value.ToString());
        }
    }
}
