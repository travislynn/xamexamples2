using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace Examples2.ViewModel
{
    public class ConnectivityPageViewModel
    {
        public string Title { get; set; }
        public string ConnectivityMessage { get; set; }
        private bool IsConnected { get; set; }
        
        public ConnectivityPageViewModel()
        {
            Title = "Connectivity Detection";
            IsConnected = CrossConnectivity.Current.IsConnected;
            ConnectivityMessage = "Connected to the internet: " + IsConnected.ToString();
        }
    }
}
