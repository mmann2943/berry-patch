using System;

namespace BerryPatch.Repository
{
    public class SiteVisitorNotLoggedInException:ApplicationException
    {
        public const string ErrorMessage = "This operation can not be performed because you are not logged in.  Log in and try again.";
        public override string Message
        {
            get { return ErrorMessage;}
        }
    }
}