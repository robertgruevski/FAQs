using Microsoft.EntityFrameworkCore;

namespace FAQs.Models
{
	public class FaqsContext : DbContext
	{
		public FaqsContext(DbContextOptions<FaqsContext> options) : base(options)
		{

		}
		public DbSet<FAQ> FAQs { get; set; } = null!;
		public DbSet<Category> Categories { get; set; } = null!;
		public DbSet<Topic> Topics { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = "gen", Name = "General" },
				new Category { CategoryId = "hist", Name = "History" }
			);

			modelBuilder.Entity<Topic>().HasData(
				new Topic { TopicId = "asp", Name = "ASP.NET Core" },
				new Topic { TopicId = "blz", Name = "Blazor" },
				new Topic { TopicId = "ef", Name = "Entity Framework" }
			);

			modelBuilder.Entity<FAQ>().HasData(
				new FAQ
				{
					FAQId = 1,
					Question = "What is ASP.NET Core?",
					Answer = "ASP.NET Core is a free and open-source web framework, and the next generation of ASP.NET, developed by Microsoft.",
					CategoryId = "gen",
					TopicId = "asp"
				},
				new FAQ
				{
					FAQId = 2,
					Question = "When was ASP.NET Core released?",
					Answer = "ASP.NET Core 1.0 was released on June 7, 2016.",
					CategoryId = "hist",
					TopicId = "asp"
				},
				new FAQ
				{
					FAQId = 3,
					Question = "What is Blazor?",
					Answer = "Blazor is a free and open-source web framework that enables developers to create web user interfaces (UI) based on components, using C# and HTML. It is being developed by Microsoft, as part of the ASP.NET Core web app framework.",
					CategoryId = "gen",
					TopicId = "blz"
				},
				new FAQ
				{
					FAQId = 4,
					Question = "When was Blazor released?",
					Answer = "Blazor was released on May 14, 2020.",
					CategoryId = "hist",
					TopicId = "blz"
				},
				new FAQ
				{
					FAQId = 5,
					Question = "What is Entity Framework?",
					Answer = "Entity Framework is an open-source ORM framework for .NET applications support by Microsoft.",
					CategoryId = "gen",
					TopicId = "ef"
				},
				new FAQ
				{
					FAQId = 6,
					Question = "When was Entity Framework released?",
					Answer = "Entity Framework 1.0 was released in 2008.",
					CategoryId = "hist",
					TopicId = "ef"
				}
			);
		}
	}
}
