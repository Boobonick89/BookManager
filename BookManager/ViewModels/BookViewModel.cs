using BookManager.Models;
using System.ComponentModel.DataAnnotations;

namespace BookManager.ViewModels
{
	public class BookViewModel
	{
		public List<Book> Books { get; set; } = new();

		public Book NewBook { get; set; } = new();

		[Required(ErrorMessage = "Введите имя автора")]
		public string AuthorName { get; set; } = string.Empty;
	}
}
