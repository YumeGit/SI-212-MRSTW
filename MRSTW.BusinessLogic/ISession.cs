using MRSTW.Domain;

namespace MRSTW.BusinessLogic
{
	public interface ISession
	{
		RequestResponse UserRegister(UserRegisterData data);
		RequestResponse UserLogin(UserLoginData data);
	}
}