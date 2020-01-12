using BookAPIs_Creation_MVCCore.DTO;
using BookAPIs_Creation_MVCCore.Serivces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviwersController :Controller
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IReviewRepository reviewRepository;

        public ReviwersController(IReviewerRepository reviewerRepository , IReviewRepository reviewRepository)
        {
            this.reviewerRepository = reviewerRepository;
            this.reviewRepository = reviewRepository;
        }


        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200,Type =typeof(IEnumerable<ReviewerDTO>))]
        public IActionResult GetReviewers()
        {
            var reviewers = reviewerRepository.GetReviewers().ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerList = new List<ReviewerDTO>();

            foreach (var item in reviewers)
            {
                reviewerList.Add(new ReviewerDTO()
                {
                     FirstName=item.first_Name,
                      Id=item.id, LastName=item.last_NameW
                });
            }

            return Ok(reviewerList);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(400)]

        [ProducesResponseType(404)]
        [ProducesResponseType(200,Type =typeof(ReviewerDTO))]

       public IActionResult GetReviewer(int reviewerId)
        {
            var reviewer = reviewerRepository.GetReviewer(reviewerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new ReviewerDTO
            {
                FirstName = reviewer.first_Name,
                Id = reviewer.id,
                LastName = reviewer.last_NameW
            };

            return Ok(model);
        }


        [HttpGet("{reviewerId}/reviews")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDTO>))]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            var reviews = reviewerRepository.GetReviewsByReviewer(reviewerId).ToList();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewList = new List<ReviewDTO>();

            foreach (var item in reviews)
            {
                reviewList.Add(new ReviewDTO()
                {
                      HeadLine=item.headline,
                       Id=item.id, Rating=item.rating, ReviewTest=item.review_Text
                });
            }

            return Ok(reviewList);
        }

        [HttpGet("{reviewId}/reviewwe")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ReviewerDTO))]
        [ProducesResponseType(404)]

        public IActionResult GetReviewerOfReview(int reviewId)
        {
            if (!reviewRepository.ReviewExist(reviewId))
                return NotFound();

            var reviewer = reviewerRepository.GetReviewerOfReview(reviewId);

            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var model = new ReviewerDTO
            {
                FirstName = reviewer.first_Name,
                Id = reviewer.id,
                LastName = reviewer.last_NameW
            };

            return Ok(model);
        }
    }
}
