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
    public class when_the_information_entered_is_not_correct: when_entering_identifying_information_following_a_successful_registration
    {
        [Test]
        public void should_navigate_to_the_page_to_notify_the_user_the_registration_process_failed()
        {
            Assert.AreEqual(SiteView.RegistrationFailure, ((ViewResult)actionResult).ViewName);
        }        
    }
}
