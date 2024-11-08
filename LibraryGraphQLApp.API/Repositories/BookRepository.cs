using LibraryGraphQLApp.API.Models;
using LibraryGraphQLApp.API.Utilities;
namespace LibraryGraphQLApp.API.Repositories;

/// <summary>
/// The BookRepository class provides CRUD operations for managing a collection of Book objects,
/// implementing the IBookRepository interface.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = [];

    /// <summary>
    /// Get all books
    /// </summary>
    /// <returns></returns>
    public OperationResult<IEnumerable<Book>> GetAllBooks()
    {
        return OperationResult<IEnumerable<Book>>.Success(_books);
    }

    /// <summary>
    /// Get a book by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OperationResult<Book> GetBookById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return OperationResult<Book>.Failure($"Book with ID {id} not found");
        }
        return OperationResult<Book>.Success(book);
    }

    /// <summary>
    /// Add a new book
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public OperationResult<Book> AddBook(Book book)
    {
        _books.Add(book);
        return OperationResult<Book>.Success(book);
    }

    /// <summary>
    /// Update an existing book
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public OperationResult<Book> UpdateBook(Book book)
    {
        var existingBookResult = GetBookById(book.Id);
        if (!existingBookResult.IsSuccess)
        {
            return OperationResult<Book>.Failure(existingBookResult.Message);
        }
        var existingBook = existingBookResult.Data;
        existingBook.Title = book.Title;
        existingBook.Genre = book.Genre;
        existingBook.AuthorId = book.AuthorId;
        existingBook.Author = book.Author;
        existingBook.Categories = book.Categories;
        return OperationResult<Book>.Success(existingBook);
    }

    /// <summary>
    /// Partially update a book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedFields"></param>
    /// <returns></returns>
    public OperationResult<Book> PatchBook(int id, Book updatedFields)
    {
        var bookResult = GetBookById(id);
        if (!bookResult.IsSuccess)
        {
            return OperationResult<Book>.Failure(bookResult.Message); 
        }

        if (updatedFields == null)
        {
            return OperationResult<Book>.Failure("Updated fields cannot be null.");
        }

        var book = bookResult.Data;
        book.Title = updatedFields.Title ?? book.Title;
        book.Genre = updatedFields.Genre ?? book.Genre;
        book.Author = updatedFields.Author ?? book.Author;

        if (updatedFields.Categories != null && updatedFields.Categories.Count > 0)
        {
            book.Categories = updatedFields.Categories;
        }

        return OperationResult<Book>.Success(book);
    }

    /// <summary>
    /// Delete a book
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    public OperationResult<bool> DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return OperationResult<bool>.Failure($"Book with ID {id} not found");
        }
        _books.Remove(book);
        return OperationResult<bool>.Success(true);
    }
}
