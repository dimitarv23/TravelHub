namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Reviews;

    public interface IReviewService
    {
        public Task AddAsync(AddReviewViewModel model);

        public Task<int> DeleteAsync(int id);

        public Task<ICollection<ReviewViewModel>> GetAllAsync(int hotelId);
    }
}