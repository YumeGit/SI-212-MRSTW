using MRSTW.Domain.Entities;

namespace MRSTW.BusinessLogic.Service
{
	public class SessionService : ModelService<Session>
	{
		public ServiceResponse<Session> GetByToken(string token)
		{
			return Find(x => x.Token == token);
		}
	}
}
