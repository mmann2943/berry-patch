using System;

namespace BerryPatch.Repository
{
    public class NonExistingFamilyMemberException: ApplicationException
    {
        public static string StaticMessage = "Sorry, but the username email combination entered is not valid.  Please try again.";
        public override string Message
        {
            get
            {
                return StaticMessage;
            }
        }
    }

    public class InvalidRegistrationCodeException : ApplicationException
    {
        public static string StaticMessage = "Sorry, but the registration code used is not valid or is already registered.  Please try again.";
        public override string Message
        {
            get
            {
                return StaticMessage;
            }
        }
    }
}