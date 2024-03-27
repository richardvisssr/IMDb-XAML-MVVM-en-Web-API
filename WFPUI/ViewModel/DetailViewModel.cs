using System.Diagnostics;
using System.Windows.Input;
using WFPUI.Commands;
using WFPUI.Model;
using WFPUI.Stores;

namespace WFPUI.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private readonly MovieStore _movieStore;
        private MovieModel _movie;

        public MovieModel Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged(nameof(Movie));
            }
        }

        public string GenresAsString
        {
            get
            {
                return string.Join(", ", Movie.Genres);
            }
        }


        public ICommand GoBackCommand { get; set; }

        public DetailViewModel(NavigationStore navigationStore, MovieStore movieStore, Func<ListViewModel> createViewModel)
        {
            _movieStore = movieStore;
            GoBackCommand = new NavigateCommand(navigationStore, movieStore ,createViewModel);
            Movie = _movieStore.SelectedMovie;
          
        }
       

    }
}