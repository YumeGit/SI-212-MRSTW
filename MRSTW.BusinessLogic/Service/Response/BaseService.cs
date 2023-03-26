namespace MRSTW.BusinessLogic.Service.Response
{
    public class BaseService
    {
        protected ServiceResponse Success()
        {
            return new ServiceResponse { Success = true };
        }

        protected ServiceResponse Failure(string message)
        {
            return new ServiceResponse { Success = false, Message = message };
        }
    }

    public struct ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}