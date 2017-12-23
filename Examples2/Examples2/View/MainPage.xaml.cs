using System;
using Xamarin.Forms;

namespace Examples2.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListViewButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }

        private void ConnectivityButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConnectivityPage());
        }
    }
}
