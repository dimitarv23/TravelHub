namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Reviews;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task AddAsync(AddReviewViewModel model)
        {
            var reviewToAdd = new Review()
            {
                Comment = model.Comment,
                UserId = model.AuthorId,
                HotelId = model.HotelId,
                DateAdded = model.DateAdded
            };

            await this.repository.AddAsync(reviewToAdd);
            await this.repository.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var reviewToDelete = await this.repository
                .GetByIdAsync<Review>(id);
            
            if (reviewToDelete == null)
            {
                return 0;
            }

            int hotelId = reviewToDelete.HotelId;

            await this.repository.DeleteAsync<Review>(id);
            await this.repository.SaveChangesAsync();

            return hotelId;
        }

        public async Task<ICollection<ReviewViewModel>> GetAllForHotelAsync(int hotelId)
        {
            return await this.repository.All<Review>()
                .Where(h => h.HotelId == hotelId)
                .Select(r => new ReviewViewModel()
                {
                    Id = r.Id,
                    Comment = r.Comment,
                    AuthorUsername = r.User.UserName,
                    AuthorId = r.UserId,
                    DateAdded = r.DateAdded
                }).ToListAsync();
        }
    }
}