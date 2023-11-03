using ControleDeLivros.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeLivros.Services.Interfaces
{
    public interface IAutorService 
    {
        Task<List<AuthorModel>> GetAuthorsAsync();
        Task<AuthorModel> GetAuthorByIdAsync(int authorId);
        Task<AuthorModel> AddAuthorAsync(AuthorModel author);
        Task<AuthorModel> UpdateAuthorAsync(int authorId, AuthorModel author);
        Task<bool> DeleteAuthorAsync(int authorId);
    }
}

