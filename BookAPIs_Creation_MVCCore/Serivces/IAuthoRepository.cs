using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
   public interface IAuthoRepository
    {
        ICollection<Author> GetAuthors();

        Author GetAuthor(int authorId);
        ICollection<Author> GetAuthorOfBook(int bookId);

        ICollection<Book> GetBookByAuthor(int authorId);

        bool AuthorExist(int authorId);
    }
}
