using ControleDeLivros.Models;
using ControleDeLivros.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeLivros.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AutorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorModel>>> GetAuthorAsync()
        {
            List<AuthorModel> authors = await _authorRepository.GetAuthorAsync();
            return Ok(authors);
        }
        [HttpGet("{AuthorId}")]
        public async Task<ActionResult<AuthorModel>> GetAuthorByIdAsync(int AuthorId)
        {
            AuthorModel authors = await _authorRepository.GetAuthorByIdAsync(AuthorId);
            return Ok(authors);
        }

        [HttpPost("cadastroAutor")]
        public async Task<ActionResult<AuthorModel>> AddAuthor([FromBody] AuthorModel authors)
        {
            AuthorModel addAuthor = await _authorRepository.AddAuthor(authors);

            return Ok(addAuthor);
        }

        [HttpPut("{AuthorId}")]
        public async Task<ActionResult<AuthorModel>> RefreshAuthor([FromBody] AuthorModel authorModel, int AuthorId)
        {
            authorModel.AuthorId = AuthorId;
            AuthorModel authorRefresh = await _authorRepository.RefreshAuthor(authorModel, AuthorId);

            return Ok(authorRefresh);
        }

        [HttpDelete("{AuthorId}")]

        public async Task<ActionResult<AuthorModel>> DeleteAuthorAsync (int AuthorId)
        {
            
            bool erased = await _authorRepository.DeleteAuthorAsync(AuthorId);
            return Ok(erased);

        }
       
    }
}
