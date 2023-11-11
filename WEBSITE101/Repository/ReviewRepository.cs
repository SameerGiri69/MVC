using WEBSITE101.Data;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddReview(ReviewDto review)
        {
           Review data = new Review();
            data.Id = review.Id;
            data.Title = review.Title;
            data.Text = review.Text;
            data.Rating = review.Rating;
            data.Pokemon = review.Pokemon;

            _context.Reviews.Add(data);
            var result = _context.SaveChanges();
            if (result < 0)
                return false;
            return true;

        }

        public bool DeleteReview(int id)
        {
            var review =_context.Reviews.Where(x => x.Id == id).FirstOrDefault();
            _context.Reviews.Remove(review);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 0)
                return false;
            return true;
        }

        

        public bool UpdateReview(ReviewDto review)
        {
            var result = _context.Reviews.Where(x=>x.Id==review.Id).FirstOrDefault();
            result.Id = review.Id;
            result.Title = review.Title;
            result.Text = review.Text;
            result.Reviewer = review.Reviewer;
            result.Rating   = review.Rating;
            _context.Reviews.Update(result);

            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 0)
                return false;
            return true;
        }


        public ReviewDto ViewReview(int id)
        {
            var result = _context.Reviews.Where(x=>x.Id==id).FirstOrDefault();
            ReviewDto reviewDto = new ReviewDto();
            reviewDto.Id = result.Id;
            reviewDto.Text = result.Text;
            reviewDto.Title = result.Title;
            reviewDto.Rating = result.Rating;

            return reviewDto;


        }
    }
}
