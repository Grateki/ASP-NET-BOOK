using ControleDeLivros.Models;
using ControleDeLivros.Repository.Interfaces;
using ControleDeLivros.Services.Interfaces;

namespace ControleDeLivros.Services.Implementation
{
    public class AutorService : IAutorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AutorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorModel>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAuthorAsync();
        }

        public async Task<AuthorModel> GetAuthorByIdAsync(int authorId)
        {
            return await _authorRepository.GetAuthorByIdAsync(authorId);
        }

        public async Task<AuthorModel> AddAuthorAsync(AuthorModel author)
        {
            return await _authorRepository.AddAuthor(author);
        }

        public async Task<AuthorModel> UpdateAuthorAsync(int authorId, AuthorModel author)
        {
            author.AuthorId = authorId; // Certifique-se de definir o ID apropriado.
            return await _authorRepository.RefreshAuthor(author, authorId);
        }

        public async Task<bool> DeleteAuthorAsync(int authorId)
        {
            return await _authorRepository.DeleteAuthorAsync(authorId);
        }
    }
}
