    using KidycareBackend.Reviews.Domain.Model.Aggregates;
    using KidycareBackend.Reviews.Domain.Model.Commands;
    using KidycareBackend.Reviews.Domain.Repositories;
    using KidycareBackend.Reviews.Domain.Services;
    using KidycareBackend.Shared.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    namespace KidycareBackend.Reviews.Application.Internal.CommandServices;

    public class ReviewCommandService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork) 
        : IReviewCommandService
    {
        
        public async Task<Review> Handle(CreateReviewCommand command)
        {
            var review = await reviewRepository.GetReviewByBabysitterIdAndParentId(command.babysitterId, command.parentId);
            if (review != null)
                throw new Exception("Review already exists");

            review = new Review(command);
            try
            {
                await reviewRepository.AddAsync(review);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return review;
        }

        public async Task<Review> Handle(UpdateReviewByIdCommand command, string reviewId)
        {
            var reviewExisting = await reviewRepository.GetReviewById(reviewId);
            if (reviewExisting == null)
                throw new Exception("Review not found");
            
            

        }

        public async Task<Review> Handle(DeleteReviewByIdCommand command)
        {
            var review = await reviewRepository.GetReviewById(command.reviewApiKey);
            if (review == null)
                throw new Exception("Review not found");

            try
            {
                await reviewRepository.DeleteReview(review.reviewApiKey);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return review;
        }
    }