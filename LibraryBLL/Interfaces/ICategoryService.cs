using System.Collections.Generic;
using LibraryBLL.DataTransferObjects;

namespace LibraryBLL.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategoty(CategoryDTO category);

        CategoryDTO GetCategory(int? id);

        CategoryDTO FindCategoryByName(string name);

        IEnumerable<CategoryDTO> GetCategories();

        void Delete(int id);

        void Dispose();
    }
}
