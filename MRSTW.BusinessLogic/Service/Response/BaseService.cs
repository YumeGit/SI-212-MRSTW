using System;

namespace MRSTW.BusinessLogic.Service.Response
{
    public class Service: IDisposable
    {
        protected ServiceResponse Success()
        {
            return new ServiceResponse { Success = true };
        }

        protected ServiceResponse Failure(string message)
        {
            return new ServiceResponse { Success = false, Message = message };
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}