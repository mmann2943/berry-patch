using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerryPatch.MVC.Models
{
    public class RegistrationModel
    {
        public string RegistrationCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZipCode { get; set; }
    }
}