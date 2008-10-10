using System;
using MbUnit.Framework;
using Rhino.Mocks;
using NBehave.Framework;

namespace Authentication.Tests
{
    
    [TestFixture]
    public class Authenticate_User
    {
        private MockRepository _mock;

        [TestFixtureSetUp]
        public void Setup()
        {
            _mock = new MockRepository();
        }

        [Test]
        public void verify_appropriate_message_when_user_authenticates_against_the_service_provider()
        {
            IUserRepository user = null;
            IAuthenticationService service = null;
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

                                                                                                                                 user = factory.Create(userName, password); })
                .When("I authenticate the user", delegate {service = _mock.DynamicMock<IAuthenticationService>();
                                                            using (_mock.Record())
                                                            {
                                                                Expect.Call(service.Authenticate(user))
                                                                    .Return(new AuthenticationStatus(new Exception("Bad Username or Password")));
                                                            }
                                                           authStatus = service.Authenticate(user);})
                .Then("I should receive an Authentication status of", Status.Failed, delegate(Status expectedStatus) {Assert.AreEqual(expectedStatus, authStatus.Status);});
        }
    }

    public enum Status
    {
        Success=0,
        Failed,
    }

    public interface IUserRepository
    {

    }

    public interface IAuthenticationService
    {
        AuthenticationStatus Authenticate(IUserRepository userToAuthenticate);
    }

    public class AuthenticationStatus
    {
        Status _status;
        string _errorMessage;
        public AuthenticationStatus(Exception exception)
        {
            _status = Status.Failed;
            _errorMessage = exception.Message;
        }

        public AuthenticationStatus()
        {
            _status = Status.Success;
        }

        public Status Status
        {
            get { return _status; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }

    public abstract class UserRepositoryFactory
    {
        public abstract IUserRepository Create(string userName, string password);
    }
}