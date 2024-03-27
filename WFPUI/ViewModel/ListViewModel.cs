using System.Collections.ObjectModel;
using WFPUI.Model;
using WFPUI.Service;
using System.Diagnostics;
using WFPUI.Commands;
using System.Windows.Input;
using WFPUI.Stores; 

namespace WFPUI.ViewModel
{
    public class ListViewModel : ViewModelBase
    {
        private readonly MovieStore _movieStore;

        private ObservableCollection<MovieModel> _movies;

        public LoadMoviesCommand LoadMoviesCommand { get; private set; }
        
        public ICommand SelectedMovieCommand { get; set; }

        public ICommand RefreshCommand { get; }

        private MovieModel _selectedMovie;

        public MovieModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
                _movieStore.SelectedMovie = _selectedMovie; 
            }
        }

        private string _statusMessage = "";
        private bool _isServerAvailable = false;

        public bool isServerAvailable
        {
            get { return _isServerAvailable; }
            set
            {
                _isServerAvailable = value;
                OnPropertyChanged(nameof(isServerAvailable));
            }
        }


        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ObservableCollection<MovieModel> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
            }
        }

        public ListViewModel(NavigationStore navigationStore, MovieStore movieStore, Func<DetailViewModel> createViewModel)
        {
            _movies = new ObservableCollection<MovieModel>();
            _selectedMovie = new MovieModel();
            Movies = _movies;
            LoadMoviesCommand = new LoadMoviesCommand(async () => await LoadMoviesAsync());
            SelectedMovieCommand = new NavigateCommand(navigationStore, movieStore ,createViewModel);
            RefreshCommand = new LoadMoviesCommand(async () => await CheckServerAvailabilityAsync());
            _movieStore = movieStore;
            CheckServerAvailabilityAsync();
        }
        public async Task CheckServerAvailabilityAsync()
        {
            isServerAvailable = await MovieService.Instance.IsServerAvailableAsync();
            if (!isServerAvailable)
            {
                StatusMessage = "Het is niet mogelijk om films in te laden omdat de server uit staat.";
            }
            else
            {
                StatusMessage = "Server is beschikbaar. Klik op de knop om films te laden";
            }
        }

        public async Task LoadMoviesAsync()
        {
            try
            {               
                await foreach (var movie in MovieService.Instance.GetMoviesAsync())
                {
                    if (!Movies.Any(m => m.MovieID == movie.MovieID))
                    {
                        Movies.Add(movie);
                    }
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                StatusMessage = "Het is niet mogelijk om films in te laden omdat de server uit staat.";
            }
        }

    }
}
