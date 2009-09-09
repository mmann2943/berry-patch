using System;
using BerryPatch.Repository;
using BerryPatch.Repository.Activity;
using BerryPatch.Repository.Security;

namespace BerryPatch.Activity
{
    public class ActivityRepository
    {
        public virtual RepositoryResult SaveActivities(SiteVisitor visitor, Activities activities)
        {            
            if (!visitor.IsLoggedIn) return new FailureResult(new SiteVisitorNotLoggedInException());

            return new ActivitySaveResult(activities.Save());
        }

        public virtual Activities GetActivities()
        {
            throw new NotImplementedException();
        }
    }

    public class ActivitySaveResult : RepositoryResult
    {
        public const string SuccessMessage = "The activities selected were saved successfully.";
        public const string ErrorMessage = "There was an error saving the selected activities.  Please try again later";
        public ActivitySaveResult(bool successfulOperation)
        {
            Success = successfulOperation;
            Message = successfulOperation
                          ? SuccessMessage
                          : ErrorMessage;
        }

        public bool Success { get; private set;}
        public string Message { get; private set;}
    }
}