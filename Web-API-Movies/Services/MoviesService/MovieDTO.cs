namespace Web_API_Movies.Services.MoviesService
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Description { get; set; }
        public decimal? AverageRating { get; set; }
        public int? NumberOfVotes { get; set; }
        public List<string> GenreName { get; set; }
        public string DirectorName { get; set; }
    }
}