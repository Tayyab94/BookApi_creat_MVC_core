using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class AuthorRepository : IAuthoRepository
    {
        private readonly BookDbContext context;

        public AuthorRepository(BookDbContext context)
        {
            this.context = context;
        }
        public bool AuthorExist(int authorId)
        {
            return context.Authors.Any(s => s.id == authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return context.Authors.Where(s => s.id == authorId).SingleOrDefault();
        }

        public ICollection<Author> GetAuthorOfBook(int bookId)
        {
            return context.BookAuthors.Where(s => s.book_Id == bookId).Select(s => s.Author).ToList();
        }

        public ICollection<Author> GetAuthors()
        {
            return context.Authors.OrderBy(s => s.last_NameW).ToList();
        }

        public ICollection<Book> GetBookByAuthor(int authorId)
        {
            return context.BookAuthors.Where(s => s.author_Id == authorId)
                .Select(s => s.Book).ToList();
        }
    }
}
