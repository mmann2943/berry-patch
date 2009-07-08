using System.Web.Mvc;
using BerryPatch.Visitor;
using BerryPath.Registration;

namespace BerryPatch.MVC.Controllers
{
    public class RegistrationController : Controller
    {
        private RegistrationService service;
        private RegistrationRepository repository;

        public RegistrationController(RegistrationService registreationService, RegistrationRepository repository)
        {
            this.service = registreationService;
            this.repository = repository;
        }

        public ActionResult Save(SiteVisitor siteVisitor)
        {
            return View();
        }

    }
}
