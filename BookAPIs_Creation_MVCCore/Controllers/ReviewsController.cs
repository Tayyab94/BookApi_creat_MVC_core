using BookAPIs_Creation_MVCCore.DTO;
using BookAPIs_Creation_MVCCore.Serivces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController:Controller
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IReviewRepository reviewRepository;

        public ReviewsController(IReviewerRepository reviewerRepository, IReviewRepository reviewRepository)
        {
            this.reviewerRepository = reviewerRepository;
            this.reviewRepository = reviewRepository;
        }


        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDTO>))]
        public IActionResult GetReviews()
        {
            var reviewers = reviewRepository.GetReviews().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewList = new List<ReviewDTO>();

            foreach (var item in reviewers)
            {
                reviewList.Add(new ReviewDTO()
                {
                    HeadLine = item.headline,
                    Id = item.id,
                    Rating = item.rating,
                    ReviewTest = item.review_Text
                });
            }

            return Ok(reviewList);
        }


        [HttpGet("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ReviewDTO))]
        public IActionResult GetReviewer(int reviewerId)
        {
            var item = reviewRepository.GetReview(reviewerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new ReviewDTO
            {
                HeadLine = item.headline,
                Id = item.id,
                Rating = item.rating,
                ReviewTest = item.review_Text
            };

            return Ok(model);
        }


        [HttpGet("{reviewId}/book")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(404)]

        public IActionResult GetBookOfReview(int reviewId)
        {
            if (!reviewRepository.ReviewExist(reviewId))
                return NotFound();

            var book = reviewRepository.GetBookOfReview(reviewId);

            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var model = new BookDTO
            { 
                 Date_Published=book.date_Published,
                  Id=book.id, 
                  Isbn=book.isbn, Title=book.title
            };

            return Ok(model);
        }


        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ReviewDTO))]
        [ProducesResponseType(404)]

        public IActionResult GetReviewsOfBook(int bookId)
        {
            //toDo Book Repository

            var reviews = reviewRepository.GetReviewsOfBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewList = new List<ReviewDTO>();

            foreach (var item in reviews)
            {
                reviewList.Add(new ReviewDTO()
                {
                     HeadLine=item.headline,
                      Id=item.id,
                       Rating=item.rating,
                        ReviewTest=item.review_Text
                });
            }

            return Ok(reviewList);
        }

    }
}
