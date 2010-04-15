using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Web.Mvc;
using Rhino.Mocks;

namespace spec_for_berry_patch.spec_for_registration.spec_for_email_login
{
    [TestFixture]
    public class when_the_user_changes_their_password
    {

        private IPasswordService passwordService;
        [SetUp]
        public void context()
        {
            passwordService = MockRepository.GenerateStub<IPasswordService>();
            var controller = new RegistrationChangePasswordConroller(passwordService);
            controller.ChangePassword("sdkajslkdsaj", "euwidhdjknwuwihd");
        }

        [Test]
        public void should_call_the_password_service_to_establish_the_new_password()
        {
            passwordService.AssertWasCalled(x => x.EstablishNewPassword(Arg<string>.Is.NotNull, Arg<string>.Is.NotNull));
        }

        [Test]
        public void should_call_the_password_service_to_clear_the_temp_password()
        {
            passwordService.AssertWasCalled(x => x.ClearTempPasswordOf(Arg<string>.Is.NotNull));
        }
    }

    public class RegistrationChangePasswordConroller : Controller
    {
        private readonly IPasswordService _passwordService;
        public RegistrationChangePasswordConroller(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public ActionResult ChangePassword(string temporaryPassword, string newPassword)
        {
            _passwordService.EstablishNewPassword(temporaryPassword, newPassword);
            _passwordService.ClearTempPasswordOf(temporaryPassword);
            
            //TODO:  Need to perform a login operation with a controller
            return null;
        }
    }
}
