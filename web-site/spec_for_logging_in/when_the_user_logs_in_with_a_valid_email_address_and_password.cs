using System;
using System.Collections.Generic;
using System.Security.Principal;
using BerryPatch.MVC.Controllers;
using BerryPatch.Repository;
using BerryPatch.Visitor;
using MbUnit.Framework;
using Rhino.Mocks;

namespace spec_for_logging_in
{
    [TestFixture]
    public class when_the_user_logs_in_with_a_valid_email_address_and_password
    {
        private IRepository<SiteVisitor> userRepository;
        private LoginController loginController;
        const string emailAddress = "mmann2943@gmail.com";
        const string password = "blahblahblah";

        
        [SetUp]
        public void context()
        {
            var principal = MockRepository.GenerateStub<IPrincipal>();
            var visitor = MockRepository.GenerateStub<SiteVisitor>();
            visitor.Stub(x => x.FirstName).Return("Michael");

            userRepository = MockRepository.GenerateStub<IRepository<SiteVisitor>>();
            userRepository.Stub(x => x.Find(Arg<Func<SiteVisitor, bool>>.Is.Anything)).Return(new List<SiteVisitor>() { visitor });

            loginController = new LoginController(userRepository);
            loginController.Submit("mmann2943@gmail.com", System.Guid.NewGuid().ToString()); 
        }

        [Test]
        public void should_use_the_user_repository_to_verify_the_credentials_of_the_user()
        {
            userRepository.AssertWasCalled(x => x.Find(Arg<Func<SiteVisitor, bool>>.Is.Anything));
        }
    }
}
