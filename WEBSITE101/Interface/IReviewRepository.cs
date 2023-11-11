using WEBSITE101.DTO;

namespace WEBSITE101.Interface
{
    public interface IReviewRepository
    {
        bool AddReview(ReviewDto review);
        ReviewDto ViewReview(int id);
        bool UpdateReview(ReviewDto review);
        bool DeleteReview(int id);
    }
}
