using LibraryGraphQLApp.API.Models;
using LibraryGraphQLApp.API.Utilities;
namespace LibraryGraphQLApp.API.Repositories;

/// <summary>
/// The AuthorRepository class implements CRUD operations for managing Author objects.
/// </summary>
public class AuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors = [];

    /// <summary>
    /// Get all authors
    /// </summary>
    /// <returns></returns>
    public OperationResult<IEnumerable<Author>> GetAllAuthors()
    {
        return OperationResult<IEnumerable<Author>>.Success(_authors);
    }


    /// <summary>
    /// Get an author by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OperationResult<Author> GetAuthorById(int id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null)
        {
            return OperationResult<Author>.Failure($"Author with ID {id} not found");
        }
        return OperationResult<Author>.Success(author);
    }

    /// <summary>
    /// Add a new author
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    public OperationResult<Author> AddAuthor(Author author)
    {
        _authors.Add(author);
        return OperationResult<Author>.Success(author);
    }

    /// <summary>
    /// Update an existing author
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    public OperationResult<Author> UpdateAuthor(Author author)
    {
        var existingAuthorResult = GetAuthorById(author.Id);
        if (!existingAuthorResult.IsSuccess)
        {
            return OperationResult<Author>.Failure(existingAuthorResult.Message);
        }
        var existingAuthor = existingAuthorResult.Data;
        existingAuthor.Name = author.Name;
        existingAuthor.Bio = author.Bio;
        existingAuthor.Books = author.Books;
        return OperationResult<Author>.Success(existingAuthor);
    }

    /// <summary>
    /// Partially update an author
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedFields"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public OperationResult<Author> PatchAuthor(int id, Author updatedFields)
    {
        var authorResult = GetAuthorById(id);
        if (!authorResult.IsSuccess)
        {
            return OperationResult<Author>.Failure(authorResult.Message);
        }
        var author = authorResult.Data;
        author.Name = updatedFields.Name ?? author.Name;
        author.Bio = updatedFields.Bio ?? author.Bio;

        if (updatedFields.Books != null && updatedFields.Books.Count > 0)
        {
            author.Books = updatedFields.Books;
        }


        return OperationResult<Author>.Success(author);
    }

    /// <summary>
    /// Delete an author
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OperationResult<bool> DeleteAuthor(int id)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author == null)
        {
            return OperationResult<bool>.Failure($"Author with ID {id} not found");
        }
        _authors.Remove(author);
        return OperationResult<bool>.Success(true);
    }

}
