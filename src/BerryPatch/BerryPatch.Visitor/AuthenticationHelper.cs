namespace BerryPatch.MVC.Controllers
{
    public class AuthenticationHelper
    {
        public static Credentials DecryptLogin(string authentication)
        {
            return new Credentials()
                       {
                           EmailAddress = "mmann2943@gmail.com",
                           Password = "blahblahblah",
                       };
            
        }

        public class Credentials
        {
            public string EmailAddress { get; set;}
            public string Password { get; set; }
        }
    }
}