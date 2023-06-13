using MRSTW.Domain.Entities;
using System;

namespace MRSTW.BusinessLogic.Service
{
    public class CommentService : ModelService<Comment>
    {
        public override ServiceResponse<Comment> Remove(Comment model)
        {
            RemoveCascade<Comment, CommentService>(model, x => x.Comments);
            RemoveCascade<Reaction, ReactionService>(model, x => x.Reactions);
            return base.Remove(model);
        }

        public ServiceResponse<IHasComments> LoadComments(IHasComments comment)
        {
            var type = comment.GetType();
            try
            {
                DbContext.Set(type).Attach(comment);
                DbContext.Entry(comment).Collection(x => x.Comments).Load();
                return Success(comment);
            }
            catch(Exception e)
            {
                return Failure<IHasComments>(e.Message);
            }
        }
	}
}
