using BookManager.Models;

namespace BookManager.ViewModels
{
	public class BookViewModel
	{
		public List<Book> Books { get; set; } = new();

		public Book NewBook { get; set; } = new();

		public string? AuthorName { get; set; } 
	}
}
