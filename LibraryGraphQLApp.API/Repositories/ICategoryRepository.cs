using LibraryGraphQLApp.API.Models;
using LibraryGraphQLApp.API.Utilities;
namespace LibraryGraphQLApp.API.Repositories;

public interface ICategoryRepository
{
    OperationResult<IEnumerable<Category>> GetAllCategories();
    OperationResult<Category> GetCategoryById(int id);
    OperationResult<Category> AddCategory(Category category);
    OperationResult<Category> UpdateCategory(Category category);
    OperationResult<Category> PatchCategory(int id, Category updatedFields);
    OperationResult<bool> DeleteCategory(int id);
}
