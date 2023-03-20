namespace MRSTW.Web.Models
{
    public class UserReaction
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Emoji { get; set; }
    }
}