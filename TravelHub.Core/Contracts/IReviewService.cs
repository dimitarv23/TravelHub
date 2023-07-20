namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Reviews;

    public interface IReviewService
    {
        public Task<ICollection<ReviewViewModel>> GetAllAsync();
    }
}