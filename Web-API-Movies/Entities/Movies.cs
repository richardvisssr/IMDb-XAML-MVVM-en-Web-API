using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_Movies.Entities
{

    public class MovieGenre
    {
        [Key, Column(Order = 0)]
        public int MovieID { get; set; }
        public Movies Movie { get; set; }

        [Key, Column(Order = 1)]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int? ReleaseYear { get; set; }

        public int DirectorID { get; set; } // Foreign key for Director
        public Director Director { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(3, 1)")]
        public decimal? AverageRating { get; set; }

        public int? NumberOfVotes { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }

    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }

    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public ICollection<Movies> Movies { get; set; } = new List<Movies>(); 
    }


}
