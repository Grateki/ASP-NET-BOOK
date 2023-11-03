using ControleDeLivros.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeLivros.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<BookModel> AddBookAsync(BookModel book);
        Task<BookModel> UpdateBookAsync(int bookId, BookModel book);
        Task<bool> DeleteBookAsync(int bookId);
    }
}
