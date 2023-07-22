namespace TravelHub.ViewModels.Reviews
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; } = null!;

        public string AuthorUsername { get; set; } = null!;

        public string AuthorId { get; set; } = null!;

        public DateTime DateAdded { get; set; }
    }
}