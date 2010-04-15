using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface NotificationService
    {
        void NotifyAdminRegCodeWasDeactivated(string registrationCode);
        void NotifyUserOfSucessfullRegistration(string registrationCode, DateTime dateOfBirth, string zipCode);
    }
}
