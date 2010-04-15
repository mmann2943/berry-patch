using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;

namespace spec_for_berry_patch.spec_for_registration
{
    [TestFixture]
    public class when_assessing_what_the_next_page_will_be: when_the_reg_code_entered_is_a_valid_reg_code
    {
        [Test]
        public void should_navigate_to_the_view_to_validate_more_information_about_the_unregistered_user()
        {
            Assert.AreEqual(SiteView.RegistrationPersonalVerification, ((ViewResult)actionResult).ViewName);
        }

    }
}
