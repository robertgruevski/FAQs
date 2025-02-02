using System.Diagnostics;
using FAQs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAQs.Controllers
{
	public class HomeController : Controller
	{
		private FaqsContext context { get; set; }
		public HomeController(FaqsContext ctx)
		{
			this.context = ctx;
		}
		public IActionResult Index(string topic, string category)
		{
			List<FAQ> faqs = context.FAQs.Include(f => f.Category).Include(f => f.Topic).OrderBy(f => f.Question).ToList(); // Select * FAQs from Database

			ViewBag.Topics = context.Topics.OrderBy(t => t.Name).ToList(); // Selecting * Topics from Database
			ViewBag.Categories = context.Categories.OrderBy(t => t.Name).ToList(); // Selecting * Categories from Database
			ViewBag.SelectedTopic = topic;

			if (!string.IsNullOrEmpty(topic))
			{
				faqs = faqs.Where(f => f.Topic.TopicId == topic).ToList();
			}
			if(!string.IsNullOrEmpty(category))
			{
				faqs = faqs.Where(f => f.Category.CategoryId == category).ToList();
			}	

			return View(faqs);
		}
	}
}
