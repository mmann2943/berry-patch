using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;

namespace spec_for_berry_patch.spec_for_registration.spec_for_email_login
{
    [TestFixture]
    public class when_the_temporary_password_is_valid: when_the_registered_user_clicks_the_email_link
    {
        protected override IPasswordService CreatePasswordService()
        {
            var service = MockRepository.GenerateStub<IPasswordService>();            
            service.Stub(x => x.IsTemporaryPasswordValid(Arg<string>.Is.Anything)).Return(true);

            return service;
        }

        [Test]
        public void should_navigate_the_user_to_the_change_password_page()
        {
            Assert.AreEqual(SiteView.ChangePassword, ((ViewResult)actionResult).ViewName);
        }
    }
}
