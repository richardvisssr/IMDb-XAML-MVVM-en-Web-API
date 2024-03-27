using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFPUI.Stores;

namespace WFPUI.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly MovieStore _movieStore;


        public MainViewModel(NavigationStore navigationStore, MovieStore movieStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _movieStore = movieStore;
            LoadMovies();
        }
        private async void LoadMovies()
        {
            await _movieStore.Load();
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
