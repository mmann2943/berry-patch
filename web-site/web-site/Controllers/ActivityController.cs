using System.Web.Mvc;
using BerryPatch.Activity;
using BerryPatch.MVC.Models;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;
using Activities=BerryPatch.Repository.Activity.Activities;

namespace web_site.Controllers
{
    public class ActivityController : Controller
    {

        private readonly ActivityRepository repository;        

        public ActivityController(ActivityRepository repository)
        {            
            this.repository = repository;
        }

        public ActivityController() : this(new ActivityRepository())
        {
              
        }


        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveActivities(SiteVisitor visitor, Activities activities)
        {            
            var result = visitor.IsLoggedIn ? repository.SaveActivities(visitor, activities) 
                                            : new FailureResult(new SiteVisitorNotLoggedInException());
            var model = new SaveActivitiesViewModel(result);
            
            return View(model);
        }        

        public ActionResult SelectActivities()
        {
            return View(new ShowActivitiesModel(repository.GetActivities()));
        }
    }

    public class Whazup
    {
        public bool Whhhhhaaaaazuuup = true;
    }

    public struct ActivityPage
    {
        public const string Select = "SelectActivities";
    }
}