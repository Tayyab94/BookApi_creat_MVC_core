using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookDbContext context;

        public ReviewRepository(BookDbContext context)
        {
            this.context = context;
        }
        public Book GetBookOfReview(int reviewId)
        {
            var bookId = context.Reviews.Where(r => r.id == reviewId).Select(s => s.Book.id).FirstOrDefault();

            return context.Books.Where(s => s.id == bookId).SingleOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return context.Reviews.Where(s => s.id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.OrderBy(s => s.rating).ToList();
        }

        public ICollection<Review> GetReviewsOfBook(int bookId)
        {
            return context.Reviews.Where(s => s.Book.id == bookId).ToList();
        }

        public bool ReviewExist(int reviewId)
        {
            return context.Reviews.Any(s => s.id == reviewId);
        }
    }
}
