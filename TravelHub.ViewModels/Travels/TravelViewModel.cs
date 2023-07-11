using System.ComponentModel.DataAnnotations;
using TravelHub.Domain.Enums;

namespace TravelHub.ViewModels.Travels
{
    public class TravelViewModel
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int PlacesLeft { get; set; }
    }
}