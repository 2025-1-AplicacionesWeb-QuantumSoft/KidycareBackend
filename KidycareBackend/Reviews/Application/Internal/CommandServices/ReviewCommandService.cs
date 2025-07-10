    using KidycareBackend.Reviews.Domain.Model.Aggregates;
    using KidycareBackend.Reviews.Domain.Model.Commands;
    using KidycareBackend.Reviews.Domain.Repositories;
    using KidycareBackend.Reviews.Domain.Services;
    using KidycareBackend.Shared.Domain.Repositories;
    using KidycareBackend.Profiles.Interfaces.ACL;

    using Microsoft.EntityFrameworkCore;

    namespace KidycareBackend.Reviews.Application.Internal.CommandServices;

    public class ReviewCommandService(IReviewRepository reviewRepository, IProfilesContextFacade profilesContextFacade, IUnitOfWork unitOfWork) 
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

        public async Task<Review> Handle(UpdateReviewByIdCommand command, int reviewId)
        {
            var existingReview = await reviewRepository.GetReviewById(reviewId);
            if (existingReview == null)
                throw new Exception("Review not found");

            try
            {
                if (!string.IsNullOrEmpty(command.comment))
                {
                    existingReview.comment = command.comment;
                }

                if (command.rating > 0)
                {
                    existingReview.rating = command.rating;
                }


                await reviewRepository.UpdateReview(existingReview);
                await unitOfWork.CompleteAsync();
                return existingReview;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        

        public async Task<Review> Handle(DeleteReviewByIdCommand command)
        {
            var review = await reviewRepository.GetReviewById(command.Id);
            if (review == null)
                throw new Exception("Review not found");

            try
            {
                await reviewRepository.DeleteReview(review.Id);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                return null;
            }

            return review;
        }
    }