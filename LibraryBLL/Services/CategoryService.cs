using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryBLL.DataTransferObjects;
using LibraryBLL.Infrastructure;
using LibraryBLL.Interfaces;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;

namespace LibraryBLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateCategoty(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new ValidationException("There is no such category", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>()).CreateMapper();
            var category = mapper.Map<CategoryDTO, Category>(categoryDTO);

            Database.Categories.Create(category);
            Database.Save();
        }

        public CategoryDTO GetCategory(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("There is no such category", "");
            }

            var category = Database.Categories.Get(id.Value);

            if (category == null)
            {
                throw new ValidationException("There is no such category", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(category);
        }

        public CategoryDTO FindCategoryByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                throw new ValidationException("There is no such category", "");
            }

            var category = Database.Categories.Find(s => s.Name == name).FirstOrDefault();

            if (category == null)
            {
                throw new ValidationException("There is no such category", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<Category, CategoryDTO>(category);
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Book, BookDTO>();
            });
            config.AssertConfigurationIsValid();

            var categories = Database.Categories.GetAll();

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categories);
        }

        public void Delete(int id)
        {
            Database.Categories.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
