using LibraryGraphQLApp.API.Models;
using LibraryGraphQLApp.API.Utilities;
namespace LibraryGraphQLApp.API.Repositories;

/// <summary>
/// The IAuthorRepository interface defines CRUD operations for managing Author objects.
/// </summary>
public interface IAuthorRepository
{
    OperationResult<IEnumerable<Author>> GetAllAuthors();
    OperationResult<Author> GetAuthorById(int id);
    OperationResult<Author> AddAuthor(Author author);
    OperationResult<Author> UpdateAuthor(Author author);
    OperationResult<Author> PatchAuthor(int id, Author updatedFields);
    OperationResult<bool> DeleteAuthor(int id);
}
