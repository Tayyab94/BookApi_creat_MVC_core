using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Category> GetCategoryForBook(int bookId);

        ICollection<Book> GetBooksForCategory(int categoryId);

        bool CategoryExist(int categoryId);
    }
}
