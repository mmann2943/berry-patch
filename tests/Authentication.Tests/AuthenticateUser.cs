using System;
using BerryPatch.Common.Enums;
using BerryPatch.Config;
using BerryPatch.Security;
using MbUnit.Framework;
using Rhino.Mocks;
using NBehave.Framework;

namespace Authentication.Tests
{
    
    [TestFixture]
    public class Authenticate_User
    {
        private MockRepository _mock;
        private IUserRepository _user;
        private IAuthenticationService _service;
        private AuthenticationStatus _authStatus;

        [TestFixtureSetUp]
        public void Setup()
        {
            _mock = new MockRepository();
        }

        [SetUp]
        public void TestSetup()
        {
            IConfig _config = _mock.CreateMock<IConfig>();
            UserRepositoryFactory factory = new CustomerRepositoryFactory(_config);
            ServiceLocator serviceLocator = new ServiceLocator(_config);
            _service = serviceLocator.FindService(typeof(IAuthenticationService));
        }

        [Test]
        public void verify_receive_appropriate_error_message_when_user_provides_a_bad_user_name_or_password()
        {
            AuthenticationStatus authStatus = null;
            Story authenticateUserStory = new Story("Authenticate User");

            authenticateUserStory.AsA("Unauthenticated user")
                .IWant("supply my user name and password to the login form")
                .SoThat("I can  authenticate to the application");

            authenticateUserStory
                .WithScenario("User provides an invalid user name")
                .Given("My user name and password are ", "Big Daddy", "Gobldegook", delegate(string userName, string password) { UserRepositoryFactory factory = _mock.DynamicMock<UserRepositoryFactory>();

                                                                                                                                 using (_mock.Record())
                                                                                                                                 {
                                                                                                                                    Expect.Call(factory.Create(userName, password))
                                                                                                                                        .Return(_mock.DynamicMock<IUserRepository>());
                                                                                                                                 }

                                                                                                                                 _user = factory.Create(userName, password); })
                .When("I authenticate the user", delegate {_service = _mock.DynamicMock<IAuthenticationService>();
                                                            using (_mock.Record())
                                                            {
                                                                Expect.Call(_service.Authenticate(_user))
                                                                    .Return(new AuthenticationStatus(new Exception("Bad Username or Password")));
                                                            }
                                                           authStatus = _service.Authenticate(_user);})
                .Then("I should receive an Authentication status of", Status.Failed, delegate(Status expectedStatus) {Assert.AreEqual(expectedStatus, authStatus.Status);});
        }
    

       [Test]
       public void verify_receive_appropriate_success_message_when_user_provides_a_good_user_name_and_password()
       {            
            Story authenticateUserStory = new Story("Authenticate User");

            authenticateUserStory.AsA("USer with a valid user name and password")
                .IWant("supply my user name and password to the login form")
                .SoThat("I can authenticate to the application");

            authenticateUserStory
                .WithScenario("User provides a valid user name and password")
                .Given("My user name and password are ", "mmann", "validpassword_1", delegate(string userName, string password) { UserRepositoryFactory factory = _mock.DynamicMock<UserRepositoryFactory>();

                                                                                                                                 using (_mock.Record())
                                                                                                                                 {
                                                                                                                                    Expect.Call(factory.Create(userName, password))
                                                                                                                                        .Return(_mock.DynamicMock<IUserRepository>());
                                                                                                                                 }

                                                                                                                                 _user = factory.Create(userName, password); })
                .When("I authenticate the user", delegate {_service = _mock.DynamicMock<IAuthenticationService>();
                                                            using (_mock.Record())
                                                            {
                                                                Expect.Call(_service.Authenticate(_user))
                                                                    .Return(new AuthenticationStatus());                                                                    
                                                            }
                                                           _authStatus = _service.Authenticate(_user);})
                .Then("I should receive an Authentication status of", Status.Success, delegate(Status expectedStatus) {Assert.AreEqual(expectedStatus, _authStatus.Status);});
        }
    }

    internal class ServiceLocator
    {
        private IConfig _config;
        public ServiceLocator(IConfig config)
        {
            _config = config;
        }

        public IAuthenticationService FindService(Type type)
        {
            string sectionName = _config.GetSections().Find(nameToFind => nameToFind.Equals("Services"));
            string typeToCreate = _config.ReadValue(type.Name, sectionName);

            var service = (IAuthenticationService)Activator.CreateInstance(Type.GetType(typeToCreate), true);
            return service;
        }        
    }
}