using ControleDeLivros.Models;
using ControleDeLivros.Repository.Interfaces;
using ControleDeLivros.Services.Implementation;
using ControleDeLivros.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeLivros.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<AuthorModel>>> GetAuthorAsync()
        {
            try
            {
                List<AuthorModel> autores = await _autorService.GetAuthorsAsync();
                return Ok(autores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter autores: {ex.Message}");
            }
        }
        [HttpGet("{AuthorId}")]
        [Produces("application/json")]
        public async Task<ActionResult<AuthorModel>> GetAuthorByIdAsync(int AuthorId)
        {
            try
            {
                AuthorModel autor = await _autorService.GetAuthorByIdAsync(AuthorId);
                if (autor != null)
                {
                    return Ok(autor);
                }
                else
                {
                    return NotFound($"Autor com ID {AuthorId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter autor: {ex.Message}");
            }
        }

        [HttpPost("cadastroAutor")]
        [Produces("application/json")]
        public async Task<ActionResult<AuthorModel>> AddAuthor([FromBody] AuthorModel autor)
        {
            try
            {
                AuthorModel addedAutor = await _autorService.AddAuthorAsync(autor);
                return CreatedAtAction(nameof(GetAuthorByIdAsync), new { AutorId = addedAutor.AuthorId }, addedAutor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar autor: {ex.Message}");
            }
        }

        [HttpPut("{AutorId}")]
        [Produces("application/json")]
        public async Task<ActionResult<AuthorModel>> UpdateAutor(int AutorId, [FromBody] AuthorModel autor)
        {
            try
            {
                AuthorModel updatedAutor = await _autorService.UpdateAuthorAsync(AutorId, autor);

                if (updatedAutor != null)
                {
                    return Ok(updatedAutor);
                }
                else
                {
                    return NotFound($"Autor com ID {AutorId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar autor: {ex.Message}");
            }
        }

        [HttpDelete("{AutorId}")]
        [Produces("application/json")]
        public async Task<ActionResult<bool>> DeleteAutorAsync(int AutorId)
        {
            try
            {
                bool deleted = await _autorService.DeleteAuthorAsync(AutorId);

                if (deleted)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound($"Autor com ID {AutorId} não encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir autor: {ex.Message}");
            }
        }

    }
}
