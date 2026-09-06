using Microsoft.AspNetCore.Mvc;
using BookManager.Data;
using System.Security.Cryptography.X509Certificates;
using BookManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Controllers
{
	public class BookController : Controller
	{
		private readonly AppDbContext _context;

		public BookController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var books =_context.Books.Include(b=>b.Author).ToList();

			return View(books);
		}

		[HttpPost]
		public IActionResult Create(string title,string genre,int year,string authorName)
		{
			var author =_context.Authors.FirstOrDefault(a=>a.Name == authorName);

			if (author == null)
			{
				author = new Models.Author
				{
					Name = authorName
				};

				_context.Authors.Add(author);
				_context.SaveChanges();

			}

			var book = new Book
			{
				Title = title,
				Genre = genre,
				Year = year,
				AuthorId = author.Id,
			};

			_context.Books.Add(book);
			_context.SaveChanges();

			return RedirectToAction("Index");

			
		}

	}
}
