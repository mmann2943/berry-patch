using System;
using System.Web.Mvc;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;

namespace BerryPatch.MVC.Controllers
{
    public class RegistrationController : Controller
    {        
        private readonly RegistrationRepository repository;
        private readonly SiteNavigator siteNavigator;

        public RegistrationController(RegistrationRepository repository, SiteNavigator siteNavigator)
        {     
            this.repository = repository;
            this.siteNavigator = siteNavigator;
        }

        public ActionResult Save(SiteVisitor siteVisitor)
        {
            if (! string.IsNullOrEmpty(siteVisitor.EmailAddress) &&
                ! string.IsNullOrEmpty(siteVisitor.LastName) &&
                ! string.IsNullOrEmpty(siteVisitor.FirstName))
            {
                repository.Register(siteVisitor);
                return siteNavigator.Navigate(SiteView.Home);
            }

            return View(new FailureResult(new RegistrationNotCompleteException()));
        }

    }

    public class RegistrationNotCompleteException : Exception
    {
        public const string MessageText = "Please make sure the EmailAddress, First and Last name are all filled in to complete registration";
        public override string Message
        {
            get
            {
                return MessageText;
            }
        }
    }

    public class SiteNavigator
    {
        public virtual ActionResult Navigate(string viewName)
        {
            throw new NotImplementedException();
        }
    }

    public struct SiteView
    {
        public const string Home = "Home";
    }
}
