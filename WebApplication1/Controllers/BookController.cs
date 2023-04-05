using ControleDeLivros.Models;
using ControleDeLivros.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeLivros.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _bookRepository;
        public BookController(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetAllBooks()
        {
            List<BookModel> books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("{BookId}")]
        public async Task<ActionResult<AuthorModel>> GetBookByIdAsync(int BookId)
        {
            BookModel books = await _bookRepository.GetBookByIdAsync(BookId);
            return Ok(books);
        }

        [HttpPost("cadastroLivro")]
        public async Task<ActionResult<BookModel>> AddBook([FromBody] BookModel books)
        {
            BookModel addBook = await _bookRepository.AddBook(books);

            return Ok(addBook);
        }

        [HttpPut("{BookId}")]
        public async Task<ActionResult<BookModel>> RefreshBooks([FromBody] BookModel bookModel, int BookId)
        {
            bookModel.BookId = BookId;
            BookModel bookRefresh = await _bookRepository.RefreshBooks(bookModel, BookId);

            return Ok(bookRefresh);
        }

        [HttpDelete("{BookId}")]

        public async Task<ActionResult<BookModel>> DeleteBook (int BookId)
        {
            
            bool erased = await _bookRepository.DeleteBook(BookId);
            return Ok(erased);

        }
       
    }
}
