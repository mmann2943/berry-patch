using BerryPatch.Repository.Activity;

namespace BerryPatch.MVC.Models
{
    public class ShowActivitiesModel
    {
        public ShowActivitiesModel(Activities activities)
        {            
            ListOfActivities = activities;
        }

        public Activities ListOfActivities {get; private set;}

        public bool ShowSaveButton { get; private set; }
    }
}
