using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wazotool_proto.Core;

namespace wazotool_proto.MVVM.ViewModel
{
    class MainViewModel :ObservableObject
    {


        public  RelayCommand MainviewCmd { get; set; }
        public  RelayCommand BO2viewCmd { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public BO2ViewModel BO2VM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }








        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            BO2VM = new BO2ViewModel();

            //first view, when booting up
            CurrentView  =  HomeVM;


            BO2viewCmd = new RelayCommand(o =>
            { 
                CurrentView = BO2VM; 
            });

            MainviewCmd = new RelayCommand(o => { CurrentView = HomeVM; });
            
            
        }
    }
}
