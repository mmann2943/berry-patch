using BerryPatch.Repository;

namespace BerryPatch.MVC.Models
{
    public class SaveActivitiesViewModel
    {
        public SaveActivitiesViewModel(RepositoryResult result)
        {
            ShowLoginContol = result is FailureResult;
            Message = result.Message;
        }

        public bool ShowLoginContol { get; private set; }

        public string Message { get; private set; }
    }
}