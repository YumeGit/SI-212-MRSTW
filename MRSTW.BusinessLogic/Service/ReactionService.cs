using MRSTW.Domain.Entities;
using System;

namespace MRSTW.BusinessLogic.Service
{
    public class ReactionService : ModelService<Reaction>
    {
        public ServiceResponse<IHasReactions> LoadReactions(IHasReactions obj)
        {
            try
            {
                var type = obj.GetType();
                DbContext.Set(type).Attach(obj);
                DbContext.Entry(obj).Collection(x => x.Reactions).Load();
                return Success(obj);
            }
            catch (Exception e)
            {
                return Failure<IHasReactions>(e.Message);
            }
        }
    }
}
