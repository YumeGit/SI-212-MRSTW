namespace MRSTW.Domain.Entities
{
	public class Reaction
	{
		public int Id { get; set; }
		public User Author { get; set; }
		public string Emoji { get; set; }
	}
}