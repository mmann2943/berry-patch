using System.Web.Mvc;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;
using BerryPatch.Web;
using web_site;

namespace BerryPatch.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepository<SiteVisitor> repository;

        public LoginController(IRepository<SiteVisitor> visitorRepository)
        {
            this.repository = visitorRepository;
        }
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(string emailAddress, string password)
        {
            var crypto = MvcApplication.Resolve<ICryptoHelper>();
            var md5Password = crypto.Encrypt(password);
            var visitorList = repository.Find(x => x.EmailAddress == emailAddress &&
                                               x.Password == md5Password);
                        
            if (visitorList == null ||
                visitorList.Count == 0)
                return View(new FailureResult(new NonExistingFamilyMemberException()));
                
            return View("WhatCanIDo", new VisitorViewModel()
                                   {
                                       Name = visitorList[0].FirstName
                                   });
        }
    }
}