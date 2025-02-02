namespace FAQs.Models
{
	public class FAQ
	{
		public int FAQId { get; set; }
		public string Question { get; set; } = string.Empty;
		public string Answer { get; set; } = string.Empty;
		public string CategoryId { get; set; } = string.Empty; // Foreign Key 
		public Category Category { get; set; } = null!; // Navigation Property
		public string TopicId { get; set; } = string.Empty;
		public Topic Topic { get; set; } = null!; // Navigation Property
	}
}
