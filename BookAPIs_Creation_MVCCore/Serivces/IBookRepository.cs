using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
  public  interface IBookRepository
    {
        ICollection<Book> GetBooks { get; set; }

        Book GetBook(int bookId);
        Book GetBook(string bookIsbn);

        decimal GetBookRating(int bookId);

        bool BookExist(int bookId);
        bool BookExist(string bookIsbn);
        bool IsDuplicateIsbn(int bookId,string bookIsbn);
    }
}
