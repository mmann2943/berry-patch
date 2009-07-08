using BerryPatch.Activity;
using BerryPatch.Visitor;

namespace BerryPatch.MVC.Models
{
    public class ShowActivitiesModel
    {
        public ShowActivitiesModel(Activities activities, SiteVisitor visitor)
        {
            ShowSaveButton = visitor.IsLoggedIn;
            ListOfActivities = activities;
        }

        public Activities ListOfActivities {get; private set;}

        public bool ShowSaveButton { get; private set; }
    }
}
