using Microsoft.AspNetCore.Mvc;
using WEBSITE101.DTO;
using WEBSITE101.Interface;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddReview(ReviewDto reviewdto)
        {
            var result =_reviewRepository.AddReview(reviewdto);
            if (result == false)
                return BadRequest();
            return Ok();

        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateReview(ReviewDto reviewdto)
        {
           var result =  _reviewRepository.UpdateReview(reviewdto);
            if (result == false)
                return NotFound();
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetReview(int id)
        {
            var result = _reviewRepository.ViewReview(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult DeleteReview(int id)
        {
            bool review = _reviewRepository.DeleteReview(id);
            if(review ==  false) return NotFound();
            return Ok();
        }
    }
}
