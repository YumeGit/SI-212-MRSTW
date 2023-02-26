using MRSTW.BusinessLogic.API;
using MRSTW.Domain;

namespace MRSTW.BusinessLogic
{
	public class SessionBL : UserAPI, ISession
    {
		public RequestResponseAction UserLogin(LoginData data)
		{
			return UserLoginAction(data);
		}
	}
}
