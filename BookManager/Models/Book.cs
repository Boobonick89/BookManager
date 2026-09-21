using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите название")]
		public string Title { get; set; }=string.Empty;

		[Required(ErrorMessage ="Введите жанр")]
		public string Genre {  get; set; }=string.Empty;

		[Required(ErrorMessage = "Введите год")]
		[Range(1,2100,ErrorMessage ="Введите корректный год")]
		public int? Year { get; set; }

		public int AuthorId	{  get; set; }

		public Author? Author { get; set; }

	}
}
