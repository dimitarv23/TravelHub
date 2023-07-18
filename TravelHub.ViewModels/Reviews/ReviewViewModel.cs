namespace TravelHub.ViewModels.Reviews
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public string AuthorUsername { get; set; } = null!;
    }
}