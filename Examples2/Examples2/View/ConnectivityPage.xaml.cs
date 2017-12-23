using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.ViewModel;
using Plugin.Connectivity;
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

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                DisplayAlert("Connectivity Changed", 
                    $"The connectivity to this device has changed to {args.IsConnected.ToString()}", 
                    "Ok", 
                    "Cancel");
            };
        }


    }
}