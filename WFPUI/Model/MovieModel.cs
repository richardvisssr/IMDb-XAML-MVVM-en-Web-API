using System.Text.Json;
using System.Text.Json.Serialization;

namespace WFPUI.Model
{
    public class MovieModel
    {
        [JsonPropertyName("movieID")]
        public int MovieID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("releaseYear")]
        public int? ReleaseYear { get; set; }

        [JsonPropertyName("genreName")]
        public List<string> Genres { get; set; } 

        [JsonPropertyName("directorName")]
        public string Director { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("averageRating")]
        public decimal? AverageRating { get; set; }

        [JsonPropertyName("numberOfVotes")]
        public int? NumberOfVotes { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    public class GenreModel
    {
        [JsonPropertyName("genreID")]
        public int GenreID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }

    public class DirectorModel
    {
        [JsonPropertyName("directorID")]
        public int DirectorID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }


}
