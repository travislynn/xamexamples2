using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.Model;
using Examples2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examples2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
	    private ListViewPageViewModel vm;
		public ListViewPage ()
		{
			InitializeComponent();
            vm = new ListViewPageViewModel();
            BindingContext = vm;
		}

	    public ListViewPage(List<Person> people)
	    {
	        InitializeComponent();
	        vm = new ListViewPageViewModel(people);
	        BindingContext = vm;
	    }

        private void AddItemButton_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new AddItemPage());
	    }
	}
}