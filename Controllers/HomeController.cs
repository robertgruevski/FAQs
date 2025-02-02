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
		public IActionResult Index(string topic)
		{
			List<FAQ> faqs = context.FAQs.Include(f => f.Category).Include(f => f.Topic).OrderBy(f => f.Question).ToList();

			if (!string.IsNullOrEmpty(topic))
			{
				faqs = faqs.Where(f => f.Topic.TopicId == topic).ToList();
			}

			return View(faqs);
		}
	}
}
