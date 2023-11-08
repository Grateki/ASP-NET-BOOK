using ControleDeLivros.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeLivros.ViewModels
{
    public class BookViewModel
    
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public DateTime? Year { get; set; }
       
        public string AuthorLastName { get; set; }

        public BookViewModel(BookModel bookModel)
        {
            BookId = bookModel.BookId;
            Title = bookModel.Title;
            Isbn = bookModel.Isbn;
            Year = bookModel.Year;
            AuthorLastName = bookModel.Author.AuthorLastName;
            
        }


    }

}
