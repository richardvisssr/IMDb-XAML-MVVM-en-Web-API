using System.Configuration;
using System.Data;
using System.Windows;
using WFPUI.Stores;
using WFPUI.ViewModel;
using WFPUI.Views;

namespace WFPUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly MovieStore _movieStore; 
        public App()
        {
            _navigationStore = new NavigationStore();
            _movieStore = new MovieStore(); 
        }
        protected override void OnStartup(StartupEventArgs e)
        {
           _navigationStore.CurrentViewModel = CreateListViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _movieStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
        private DetailViewModel CreateDetailViewModel()
        {
            return new DetailViewModel(_navigationStore, _movieStore ,CreateListViewModel);
        }

        private ListViewModel CreateListViewModel()
        {
            return new ListViewModel(_navigationStore, _movieStore ,CreateDetailViewModel);
        }
    }

}
