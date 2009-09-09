using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Autofac.Integration.Web;
using BerryPatch.Repository;
using BerryPatch.ViewModel;
using BerryPatch.Visitor;
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
            var visitor = repository.Find(x => x.EmailAddress == emailAddress &&
                                               x.Password == md5Password)[0];
            
            return View("WhatCanIDo", new VisitorViewModel()
                                   {
                                       Name = visitor.FirstName
                                   });
        }
    }

    public class MD5Helper: ICryptoHelper
    {
        public string Encrypt(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var encoding = new UTF8Encoding();
            var bytes = encoding.GetBytes(password);
            return encoding.GetString(md5.ComputeHash(bytes));
        }
    }

    public interface ICryptoHelper
    {
        string Encrypt(string stringToencrypt);
    }
}