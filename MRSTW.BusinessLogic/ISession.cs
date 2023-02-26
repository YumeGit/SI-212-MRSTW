using MRSTW.Domain;

namespace MRSTW.BusinessLogic
{
    public interface ISession
    {
        RequestResponseAction UserLogin(LoginData data);
    }
}