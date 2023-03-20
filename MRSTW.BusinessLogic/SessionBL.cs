using MRSTW.BusinessLogic.API;
using MRSTW.Domain;

namespace MRSTW.BusinessLogic
{
	public class SessionBL : UserApi, ISession
	{
		public RequestResponseAction UserLogin(ULoginData data)
		{
			return UserLoginAction(data);
		}
	}
}
