using MRSTW.BusinessLogic.API;
using MRSTW.Domain;

namespace MRSTW.BusinessLogic
{
	public class SessionBL : UserApi, ISession
	{
		public RequestResponse UserLogin(UserLoginData data)
		{
			return UserLoginAction(data);
		}
	}
}
