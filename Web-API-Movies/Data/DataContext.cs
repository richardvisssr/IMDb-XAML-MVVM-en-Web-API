using Microsoft.EntityFrameworkCore;

namespace Web_API_Movies.Data

{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieID, mg.GenreID });
        }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
