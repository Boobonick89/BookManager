using BookManager.Data;
using BookManager.Models;
using BookManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

		[HttpPost]
		public IActionResult Create(BookViewModel viewModel)
		{

			if(string.IsNullOrWhiteSpace(viewModel.AuthorName))
			{
				ModelState.AddModelError("AuthorName", "Введите имя автора");
				
			}	

			if (!ModelState.IsValid)
			{
				viewModel.Books = _context.Books.Include(b => b.Author).ToList();

				ViewBag.HasFilters = false;

				return View("Index", viewModel);
			}

			var author = _context.Authors.FirstOrDefault(a => a.Name == viewModel.AuthorName);

			if (author == null)
			{
				author = new Author
				{
					Name = viewModel.AuthorName
				};

				_context.Authors.Add(author);
				_context.SaveChanges();

			}

			viewModel.NewBook.AuthorId = author.Id;

			_context.Books.Add(viewModel.NewBook);
			_context.SaveChanges();

			return RedirectToAction("Index");

		}

		[HttpPost]
		public IActionResult Edit(int id, string title, string genre, int year, string authorName)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == id);

			if (book == null)
			{
				return RedirectToAction("Index");
			}

			var author = _context.Authors.FirstOrDefault(a => a.Name == authorName);

			if (author == null)
			{
				author = new Author
				{
					Name = authorName
				};

				_context.Authors.Add(author);
				_context.SaveChanges();
			}

			book.Title = title;
			book.Genre = genre;
			book.Year = year;
			book.AuthorId = author.Id;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var book = _context.Books.FirstOrDefault(b => b.Id == id);

			if (book == null)
			{
				return RedirectToAction("Index");
			}

			_context.Books.Remove(book);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Index(string? search, string? author, string? genre, int? yearFrom, int? yearTo)
		{
			IQueryable<Book> query = _context.Books;

			query = query.Include(b => b.Author);

			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(b => b.Title.Contains(search));
			}

			if (!string.IsNullOrWhiteSpace(author))
			{
				query = query.Where(b =>
				 b.Author != null &&
				b.Author.Name.Contains(author));
			}

			if (!string.IsNullOrWhiteSpace(genre))
			{
				query = query.Where(b => b.Genre.Contains(genre));
			}

			if (yearFrom.HasValue)
			{
				query = query.Where(b => b.Year >= yearFrom.Value);
			}


			if (yearTo.HasValue)
			{
				query = query.Where(b => b.Year <= yearTo.Value);
			}

			ViewBag.HasFilters = !string.IsNullOrWhiteSpace(search)
								|| !string.IsNullOrWhiteSpace(author)
								|| !string.IsNullOrWhiteSpace(genre)
								|| yearFrom.HasValue
								|| yearTo.HasValue;

			var viewModel = new BookViewModel();
			viewModel.Books = query
			.OrderBy(b => b.Title)
			.ToList();

			return View(viewModel);

		}
	}
}
