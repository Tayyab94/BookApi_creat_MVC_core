using BookAPIs_Creation_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Serivces
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly BookDbContext context;

        public ReviewerRepository(BookDbContext context)
        {
            this.context = context;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return context.Reviewers.Where(s => s.id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfReview(int reviewId)
        {
            var revId= context.Reviews.Where(s => s.id == reviewId).Select(s => s.Reviewer.id).FirstOrDefault();

            return context.Reviewers.Where(s => s.id == revId).SingleOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return context.Reviewers.OrderBy(s=>s.last_NameW).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return context.Reviews.Where(s => s.Reviewer.id == reviewerId)
                .ToList();
        }

        public bool ReviewerExist(int reviewerId)
        {
            return context.Reviewers.Any(a => a.id == reviewerId);
        }

        Reviewer IReviewerRepository.GetReviewerOfReview(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
