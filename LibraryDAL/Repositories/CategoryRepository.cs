using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.EF;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;

namespace LibraryDAL.Repositories
{
    public class CategoryRepository  : IRepository<Category>
    {
        private LibraryContext dataBase;

        public CategoryRepository(LibraryContext context)
        {
            this.dataBase = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return dataBase.Categories.Include(c => c.Books);
        }

        public Category Get(int id)
        {
            return dataBase.Categories.Find(id);
        }

        public void Create(Category category)
        {
            dataBase.Categories.Add(category);
        }

        public void Update(Category category)
        {
            dataBase.Entry(category).State = EntityState.Modified;
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return dataBase.Categories.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Category category = dataBase.Categories.Find(id);
            if (category != null)
            {
                dataBase.Categories.Remove(category);
                dataBase.SaveChanges();
            }
        }
    }
}
