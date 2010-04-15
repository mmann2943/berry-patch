using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Rhino.Mocks;
using spec_for_registration;
using BerryPatch.MVC.Controllers;
using System.Web.Mvc;

namespace spec_for_berry_patch.spec_for_registration
{
    [TestFixture]
    public class when_the_reg_code_entered_is_a_valid_reg_code : when_a_site_visitor_attempts_to_register
    {
        public override void observe()
        {
            registrationRepository.Stub(x => x.IsValidRegCode(RegistrationCode)).Return(true);
        }
    }
}
