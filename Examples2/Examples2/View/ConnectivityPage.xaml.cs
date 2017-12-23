using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examples2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectivityPage : ContentPage
    {

        private ConnectivityPageViewModel vm;

        public ConnectivityPage()
        {
            InitializeComponent();
            vm = new ConnectivityPageViewModel();
            BindingContext = vm;
        }


    }
}