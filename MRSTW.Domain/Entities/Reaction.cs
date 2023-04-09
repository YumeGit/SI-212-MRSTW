namespace MRSTW.Domain.Entities
{
	public class Reaction
	{
		public int Id { get; set; }
		public User User { get; set; }
		public string Emoji { get; set; }
	}
}