using CustomerManager_WPF_SQL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager_WPF_SQL.Models.ViewModels
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand CreateCustomerViewCommand { get; set; }
        public RelayCommand ListCustomerCommand { get; set; }
        public RelayCommand CreateErrandViewCommand { get; set; }
        public RelayCommand ListErrandViewCommand { get; set; }


        public CreateCustomerViewModel CreateCustomerViewModel { get; set; }
        public ListCustomerViewModel ListCustomerViewModel { get; set; }
        public CreateErrandViewModel CreateErrandViewModel { get; set; }
        public ListErrandViewModel ListErrandViewModel { get; set; }


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            CreateCustomerViewModel = new CreateCustomerViewModel();
            ListCustomerViewModel = new ListCustomerViewModel();
            CreateErrandViewModel = new CreateErrandViewModel();
            ListErrandViewModel = new ListErrandViewModel();
            CurrentView = ListCustomerViewModel;

            CreateCustomerViewCommand = new RelayCommand(x => CurrentView = CreateCustomerViewModel);
            ListCustomerCommand = new RelayCommand(x => CurrentView = ListCustomerViewModel);
            CreateErrandViewCommand = new RelayCommand(x => CurrentView = CreateErrandViewModel);
            ListErrandViewCommand = new RelayCommand(x => CurrentView = ListErrandViewModel);


        }
    }
}
