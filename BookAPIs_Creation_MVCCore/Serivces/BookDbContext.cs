using BookAPIs_Creation_MVCCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }

        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory>  BookCategories { get; set; }


        //protected override void onModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.book_Id, bc.category_Id });

        //    modelBuilder.Entity<BookCategory>().HasOne(b => b.Book).WithMany(bc => bc.BookCategories).HasForeignKey(b=>b.book_Id);

        //    modelBuilder.Entity<BookCategory>().HasOne(c => c.Category).WithMany(bc => bc.BookCategories).HasForeignKey(c => c.category_Id);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            #region Many to many relation with book and category
            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.book_Id, bc.category_Id });
            modelBuilder.Entity<BookCategory>().HasOne(b => b.Book).WithMany(bc => bc.BookCategories).HasForeignKey(b => b.book_Id);
            modelBuilder.Entity<BookCategory>().HasOne(c => c.Category).WithMany(bc => bc.BookCategories).HasForeignKey(c => c.category_Id);
            #endregion


            #region Many to many With Book and Author
            modelBuilder.Entity<BookAuthor>().HasKey(bc => new { bc.book_Id, bc.author_Id });
            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Book).WithMany(ba => ba.BookAuthors).HasForeignKey(b => b.book_Id);
            modelBuilder.Entity<BookAuthor>().HasOne(a => a.Author).WithMany(ba => ba.BookAuthors).HasForeignKey(a => a.author_Id);
            #endregion

        }
    }
}
