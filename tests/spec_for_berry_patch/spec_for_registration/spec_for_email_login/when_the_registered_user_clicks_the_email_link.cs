using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Web.Mvc;
using Rhino.Mocks;
using BerryPatch.MVC.Controllers;

namespace spec_for_berry_patch.spec_for_registration.spec_for_email_login
{
    public class when_the_registered_user_clicks_the_email_link
    {
        IPasswordService _passwordService;
        protected ActionResult actionResult;

        [SetUp]
        public void context()
        {
            _passwordService = CreatePasswordService();
            var controller = new RegistrationLoginController(_passwordService);
            actionResult = controller.Index("asdsadsadasdsaew312");
        }

        protected virtual IPasswordService CreatePasswordService()
        {
            var service = MockRepository.GenerateStub<IPasswordService>();
            
            return service;
        }

        [Test]
        public void should_verify_the_password_is_a_valid_password()
        {
            _passwordService.AssertWasCalled(x => x.IsTemporaryPasswordValid(Arg<string>.Is.Anything));
        }        
    }

    public class RegistrationLoginController: Controller
    {
        private readonly IPasswordService _passwordService;
        public RegistrationLoginController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        
        public ActionResult Index(string temporaryPassword)
        {
            if (_passwordService.IsTemporaryPasswordValid(temporaryPassword))
            {
                return View(SiteView.ChangePassword);
            }
            return View(SiteView.Home);
        }
    }

    public interface IPasswordService
    {
        bool IsTemporaryPasswordValid(string temporaryPassword);
        void ClearTempPasswordOf(string temporaryPassword);

        void EstablishNewPassword(string temporaryPassword, string newPassword);
    }
}
