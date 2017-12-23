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
	public partial class AddItemPage : ContentPage
	{
	    private AddItemPageViewModel vm;

	    private List<Person> people = new List<Person>();

		public AddItemPage ()
		{
			InitializeComponent();
            vm = new AddItemPageViewModel();
            BindingContext = vm;
		}

	    private void AddEntryButton_OnClicked(object sender, EventArgs e)
	    {
	        if (vm.AddEntry())
	        {
	            GoToList();
	        }
	    }

	    private void GoToListButton_OnClicked(object sender, EventArgs e)
	    {
	        GoToList();
	    }

	    private void GoToList()
	    {
	        Navigation.PushAsync(new ListViewPage(vm.People), true);
        }
    }
}