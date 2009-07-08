using System;

namespace BerryPatch.Repository
{
    public class FailureResult:RepositoryResult
    {
        private readonly Exception _exception;

        public FailureResult(Exception exception)
        {
            _exception = exception;
            Message = exception.Message;
        }

        public bool Success
        {
            get { return false; }
        }

        public string Message { get; private set;}

        public Exception Exception
        {
            get { return _exception; }
        }
    }
}