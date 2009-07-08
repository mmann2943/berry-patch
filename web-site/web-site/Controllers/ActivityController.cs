using System;
using System.Security.Principal;
using System.Web.Mvc;
using BerryPatch.Activity;
using BerryPatch.MVC.Models;
using BerryPatch.Repository;
using BerryPatch.Visitor;
using Activities=BerryPatch.Activity.Activities;

namespace web_site.Controllers
{
    public class ActivityController : Controller
    {

        private readonly ActivityRepository repository;        

        public ActivityController(ActivityRepository repository)
        {            
            this.repository = repository;
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

        public ActionResult ShowActivities(SiteVisitor visitor)
        {
            return View(new ShowActivitiesModel(repository.GetActivities(), visitor));
        }
    }

    public class Visitor: SiteVisitor
    {
        private readonly IPrincipal userPrincipal;

        public Visitor(IPrincipal userPrincipal)
        {
            this.userPrincipal = userPrincipal;            
        }

        public bool IsLoggedIn
        {
            get { return userPrincipal.Identity.IsAuthenticated; }
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