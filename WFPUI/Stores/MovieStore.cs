using WFPUI.Model;
using System.Collections.ObjectModel;
using WFPUI.Service;
using System.ComponentModel;



namespace WFPUI.Stores
{
    public class MovieStore : INotifyPropertyChanged
    {
        private ObservableCollection<MovieModel> _movies = new ObservableCollection<MovieModel>();
        private MovieService _movieService = MovieService.Instance;

        private MovieModel _selectedMovie;
        public MovieModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (_selectedMovie != value)
                {
                    _selectedMovie = value;
                    OnPropertyChanged(nameof(SelectedMovie));
                }
            }
        }

        public async Task Load()
        {
            _movies.Clear();
            await foreach (var movie in _movieService.GetMoviesAsync())
            {
                _movies.Add(movie);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

