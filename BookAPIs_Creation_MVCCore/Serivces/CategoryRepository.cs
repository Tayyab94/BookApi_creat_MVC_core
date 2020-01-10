using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext context;

        public CategoryRepository(BookDbContext context)
        {
            this.context = context;
        }
        public bool CategoryExist(int categoryId)
        {
            return context.Categories.Any(c => c.id == categoryId);
        }

        public ICollection<Book> GetBooksForCategory(int categoryId)
        {

            return context.BookCategories.Where(s => s.category_Id == categoryId).Select(s => s.Book).ToList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return context.Categories.Where(s => s.id == categoryId).FirstOrDefault();
        }

        public ICollection<Category> GetCategoryForBook(int bookId)
        {
            var ss= context.BookCategories.Where(s => s.book_Id == bookId).Select(s => s.Category).ToList();
            return ss;
        }
    }
}
