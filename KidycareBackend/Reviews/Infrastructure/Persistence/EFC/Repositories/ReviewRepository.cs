﻿using KidycareBackend.Reviews.Domain.Model.Aggregates;
using KidycareBackend.Reviews.Domain.Repositories;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Configuration;
using KidycareBackend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidycareBackend.Reviews.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public Task<IEnumerable<Review>> GetReviewByParentId(string parentId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetReviewByBabysitterId(string babysitterId)
    {
        throw new NotImplementedException();
    }

    public async Task<Review> GetReviewById(string reviewId)
    {
        return await Context.Set<Review>().
            FirstOrDefaultAsync(r => r.reviewApiKey == reviewId);
    }
    
    public async Task<Review> GetReviewByBabysitterIdAndParentId(object babysitterId, object parentId)
    {
        return await Context.Set<Review>().
            FirstOrDefaultAsync(r => r.babysitterId == babysitterId && r.parentId == parentId);
    }

    public async Task<Review> UpdateReview(Review reviewId)
    {
        Context.Set<Review>().Update(reviewId);
        await Context.SaveChangesAsync();
        return reviewId;
    }
    
    public async Task DeleteReview(string reviewId)
    {
        Context.Set<Review>().Remove(await GetReviewById(reviewId));
    }
}