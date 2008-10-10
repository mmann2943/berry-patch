using System;
using BerryPatch.Common.Enums;

namespace BerryPatch.Security
{
    public class AuthenticationStatus
    {
        Status _status;
        string _errorMessage;
        public AuthenticationStatus(Exception exception)
        {
            _status = Status.Failed;
            _errorMessage = exception.Message;
        }

        public AuthenticationStatus()
        {
            _status = Status.Success;
        }

        public Status Status
        {
            get { return _status; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}