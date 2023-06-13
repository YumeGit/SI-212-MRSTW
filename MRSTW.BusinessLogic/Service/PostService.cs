using MRSTW.Domain.Entities;

namespace MRSTW.BusinessLogic.Service
{
    public class PostService : ModelService<Post>
	{
        public override ServiceResponse<Post> Remove(Post model)
        {
            RemoveCascade<Comment, CommentService>(model, x => x.Comments);
            RemoveCascade<Reaction, ReactionService>(model, x => x.Reactions);
            return base.Remove(model);
        }
    }
}
