namespace TravelHub.Domain.Common
{
    public class GlobalConstants
    {
        public static class Shared
        {
            public const string DateFormat = "{0:dd/MM/yyyy}";

            public const string RequiredErrorMessage = "This field is required.";
            public const string StringLengthErrorMessage = "Length should be between {0} and {1} characters.";
        }

        public static class User
        {
            public const int NamesMinLength = 2;
            public const int NamesMaxLength = 30;

            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 20;
        }

        public static class Travel
        {
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 2000;

            public const int PriceMinValue = 0;
            public const int PriceMaxValue = 10000;

            public const int NumOfPeopleMinValue = 10;
            public const int NumOfPeopleMaxValue = 200;
        }

        public static class Destination
        {
            public const int CountryMinLength = 4;
            public const int CountryMaxLength = 50;

            public const int PlaceMinLength = 2;
            public const int PlaceMaxLength = 50;

            public const int CurrencyMinLength = 3;
            public const int CurrencyMaxLength = 20;
        }

        public static class Hotel
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;
        }

        public static class Review
        {
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;

            public const int CommentMinLength = 10;
            public const int CommentMaxLength = 500;
        }
    }
}