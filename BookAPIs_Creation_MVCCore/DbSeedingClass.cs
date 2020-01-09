using BookAPIs_Creation_MVCCore.Models;
using BookAPIs_Creation_MVCCore.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore
{
    public static class DbSeedingClass
    {
        public static void SeedDataContext(this BookDbContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "123",
                        title = "The Call Of The Wild",
                        date_Published = new DateTime(1903,1,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { name = "Action"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { headline = "Awesome Book", review_Text = "Reviewing Call of the Wild and it is awesome beyond words", rating = 5,
                             Reviewer = new Reviewer(){ first_Name = "John", last_NameW = "Smith" } },
                            new Review { headline = "Terrible Book", review_Text = "Reviewing Call of the Wild and it is terrrible book", rating = 1,
                             Reviewer = new Reviewer(){ first_Name = "Peter", last_NameW = "Griffin" } },
                            new Review { headline = "Decent Book", review_Text = "Not a bad read, I kind of liked it", rating = 3,
                             Reviewer = new Reviewer(){ first_Name = "Paul", last_NameW = "Griffin" } }
                        }
                    },
                    Author = new Author()
                    {
                        first_Name = "Jack",
                        last_NameW = "London",
                        Country = new Country()
                        {
                            name = "USA"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "1234",
                        title = "Winnetou",
                        date_Published = new DateTime(1878,10,1),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() {  name  = "Western"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { headline = "Awesome Western Book", review_Text = "Reviewing Winnetou and it is awesome book", rating = 4,
                             Reviewer = new Reviewer(){ first_Name = "Frank", last_NameW = "Gnocci" } }
                        }
                    },
                    Author = new Author()
                    {
                        first_Name = "Karl",
                        last_NameW = "May",
                        Country = new Country()
                        {
                            name = "Germany"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "12345",
                        title = "Pavols Best Book",
                        date_Published = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { name = "Educational"}},
                            new BookCategory { Category = new Category() { name = "Computer Programming"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { headline = "Awesome Programming Book", review_Text = "Reviewing Pavols Best Book and it is awesome beyond words", rating = 5,
                             Reviewer = new Reviewer(){ first_Name = "Pavol2", last_NameW = "Almasi2" } }
                        }
                    },
                    Author = new Author()
                    {
                        first_Name = "Pavol",
                        last_NameW = "Almasi",
                        Country = new Country()
                        {
                            name = "Slovakia"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "123456",
                        title = "Three Musketeers",
                        date_Published = new DateTime(2019,2,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { name = "Action"}},
                            new BookCategory { Category = new Category() { name = "History"}}
                        }
                    },
                    Author = new Author()
                    {
                        first_Name = "Alexander",
                        last_NameW = "Dumas",
                        Country = new Country()
                        {
                             name = "France"
                        }
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        isbn = "1234567",
                        title = "Big Romantic Book",
                        date_Published = new DateTime(1879,3,2),
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { name = "Romance"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { headline = "Good Romantic Book", review_Text = "This book made me cry a few times", rating = 5,
                             Reviewer = new Reviewer(){ first_Name = "Allison", last_NameW = "Kutz" } },
                            new Review { headline = "Horrible Romantic Book", review_Text = "My wife made me read it and I hated it", rating = 1,
                             Reviewer = new Reviewer(){ first_Name = "Kyle", last_NameW = "Kutz" } }
                        }
                    },
                    Author = new Author()
                    {
                        first_Name = "Anita",
                        last_NameW = "Powers",
                        Country = new Country()
                        {
                            name = "Canada"
                        }
                    }
                }
            };

            context.BookAuthors.AddRange(booksAuthors);
            context.SaveChanges();

        }
    }
}
