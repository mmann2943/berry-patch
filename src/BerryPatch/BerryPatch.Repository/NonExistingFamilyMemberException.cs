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
}