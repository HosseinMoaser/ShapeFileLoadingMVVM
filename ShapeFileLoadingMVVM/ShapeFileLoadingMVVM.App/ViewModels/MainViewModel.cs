using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public HomeViewModel HomeViewModel { get; }

        public MainViewModel(HomeViewModel homeViewModel)
        {
            HomeViewModel = homeViewModel;
        }
    }
}
