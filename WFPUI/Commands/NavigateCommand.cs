using System;
using WFPUI.Model;
using WFPUI.Stores;
using WFPUI.ViewModel;

namespace WFPUI.Commands
{
    class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly MovieStore _movieStore;
        public readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, MovieStore movieStore , Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _movieStore = movieStore;
        }

        public override void Execute(object? parameter)
        {
            _movieStore.SelectedMovie = parameter as MovieModel;
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
