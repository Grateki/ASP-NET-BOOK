using ControleDeLivros.Models;
using ControleDeLivros.Repository.Interfaces;
using ControleDeLivros.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeLivros.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _bookRepository;

        public BookService(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooks();
            return books ?? new List<BookModel>();
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            return book ?? new BookModel(); 
        }

        public async Task<BookModel> AddBookAsync(BookModel book)
        {
            return await _bookRepository.AddBook(book) ?? new BookModel(); 
        }

        public async Task<BookModel> UpdateBookAsync(int bookId, BookModel book)
        {
            book.BookId = bookId;
            return await _bookRepository.RefreshBooks(book, bookId) ?? new BookModel(); 
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            return await _bookRepository.DeleteBook(bookId);
        }
    }
}
