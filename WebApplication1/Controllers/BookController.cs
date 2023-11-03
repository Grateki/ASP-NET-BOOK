using ControleDeLivros.Models;
using ControleDeLivros.Services;
using ControleDeLivros.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeLivros.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetAllBooks()
        {
            try
            {
                List<BookModel> books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter livros: {ex.Message}");
            }
        }
        [HttpGet("{BookId}")]
        public async Task<ActionResult<AuthorModel>> GetBookByIdAsync(int BookId)
        {
            try
            {
                BookModel book = await _bookService.GetBookByIdAsync(BookId);
                if (book != null)
                {
                    return Ok(book);
                }
                else
                {
                    return NotFound($"Livro com ID {BookId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter livro: {ex.Message}");
            }
        }

        [HttpPost("cadastroLivro")]
        public async Task<ActionResult<BookModel>> AddBook([FromBody] BookModel books)
        {
            try
            {
                BookModel addedBook = await _bookService.AddBookAsync(books);
                return CreatedAtAction(nameof(GetBookByIdAsync), new { BookId = addedBook.BookId }, addedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar livro: {ex.Message}");
            }
        }

        [HttpPut("{BookId}")]
        public async Task<ActionResult<BookModel>> RefreshBooks([FromBody] BookModel bookModel, int BookId)
        {
            try
            {
                BookModel updatedBook = await _bookService.UpdateBookAsync(BookId, bookModel);

                if (updatedBook != null)
                {
                    return Ok(updatedBook);
                }
                else
                {
                    return NotFound($"Livro com ID {BookId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar livro: {ex.Message}");
            }
        }

        [HttpDelete("{BookId}")]

        public async Task<ActionResult<BookModel>> DeleteBook (int BookId)
        {
            try
            {
                bool deleted = await _bookService.DeleteBookAsync(BookId);

                if (deleted)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"Livro com ID {BookId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir livro: {ex.Message}");
            }
        }
       
    }
}
