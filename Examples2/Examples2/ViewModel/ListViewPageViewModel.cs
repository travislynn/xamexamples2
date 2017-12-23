using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.Data;
using Examples2.Model;

namespace Examples2.ViewModel
{
    public class ListViewPageViewModel
    {
        public string Title { get; set; }
        public ObservableCollection<Person> People { get; set; }

        private PersonRepository repo = new PersonRepository();

        public ListViewPageViewModel()
        {
            var peop = repo.GetAll();
            InitViewModel(peop.ToList());
        }

        public ListViewPageViewModel(List<Person> people)
        {
            InitViewModel(people);
        }

        private void InitViewModel(List<Person> people)
        {
            Title = "List of all Peoples";
            if (people != null && people.Count() > 0)
            {
                People = new ObservableCollection<Person>(people);
            }
            else
            {
                People = new ObservableCollection<Person>();
            }
        }


    }
}
