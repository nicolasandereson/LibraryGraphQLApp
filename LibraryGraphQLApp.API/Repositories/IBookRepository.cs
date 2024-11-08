using LibraryGraphQLApp.API.Models;
using LibraryGraphQLApp.API.Utilities;
namespace LibraryGraphQLApp.API.Repositories;

/// <summary>
/// The IBookRepository interface defines CRUD operations for managing Book objects.
/// </summary>
public interface IBookRepository
{
    OperationResult<IEnumerable<Book>> GetAllBooks();
    OperationResult<Book> GetBookById(int id);
    OperationResult<Book> AddBook(Book book);
    OperationResult<Book> UpdateBook(Book book);
    OperationResult<Book> PatchBook(int id, Book updatedFields);
    OperationResult<bool> DeleteBook(int id);
}
