namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.ViewModels.Reviews;

    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public Task<ICollection<ReviewViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}