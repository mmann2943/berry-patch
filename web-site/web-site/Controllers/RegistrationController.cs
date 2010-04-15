using System;
using System.Web.Mvc;
using BerryPatch.Repository;
using BerryPatch.Repository.Security;
using System.Collections;
using Services;
using BerryPatch.MVC.Models;

namespace BerryPatch.MVC.Controllers
{
    public class RegistrationController : Controller
    {        
        private readonly RegistrationRepository _repository;
        private readonly NotificationService _notificationService;
        public const int MaximumNumberOfTimesToEnterRegCode = 3;
        public RegistrationController(RegistrationRepository repository, NotificationService notificationService)
        {     
            _repository = repository;
            _notificationService = notificationService;
        }

        public ActionResult EnterRegCode(string registrationCode)
        {

            if (_repository.IsValidRegCode(registrationCode))
                return View(SiteView.RegistrationPersonalVerification);

            if (_repository.NumberOfTimesRegCodeEnteredToday(registrationCode) > MaximumNumberOfTimesToEnterRegCode)
            {
                _repository.DeactivateRegCode(registrationCode);
                _notificationService.NotifyAdminRegCodeWasDeactivated(registrationCode);
                return View(SiteView.RegistrationCodeIsDisabled);
            }
                
            ViewData[ViewDataLookupKeys.MessageToDisplay] = MessagesToDisplay.InvalidRegCodeMessage;
            return View(SiteView.EnterRegistrationCode);
        }

        public ActionResult VerifyPersonalInformation(string registrationCode, DateTime dateOfBirth, string zipCode)
        {
            if (_repository.PersonalInformationIsValid(registrationCode, dateOfBirth, zipCode ))
            {
                _notificationService.NotifyUserOfSucessfullRegistration(registrationCode, dateOfBirth, zipCode);
                return View(SiteView.RegistrationSuccess);
            }
                
            return View(SiteView.RegistrationFailure);            
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
        public const string RegistrationPersonalVerification = "VerifyWhoYouAre";
        public const string EnterRegistrationCode = "EnterRegistrationCode";
        public const string RegistrationCodeIsDisabled = "DisabledRegCode";
        public const string RegistrationSuccess = "RegistrationSuccess";
        public const string RegistrationFailure = "RegistrationFailure";
        public const string ChangePassword = "ChangePassword";
    }

    public struct MessagesToDisplay
    {
        public const string InvalidRegCodeMessage = "The registration code entered is either invalid or already registered.  Please try again.";
    }

    public struct ViewDataLookupKeys
    {
        public const string MessageToDisplay = "Message";
    }

    public class PersonalInformationModel
    {
        public DateTime DateOfBirth;
        public string ZipCode;
    }
}
