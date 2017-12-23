using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.Data;
using Examples2.Model;

namespace Examples2.ViewModel
{
    public class AddItemPageViewModel
    {
        public string Title { get; set; }
        public string FirstNameEntry { get; set; }
        public string LastNameEntry { get; set; }
        public string PhoneNumberEntry { get; set; }
        public string EntryErrors { get; set; }

        private PersonRepository repo;

        private List<Person> _people;
        public List<Person> People
        {
            get
            {
                //_people ?? (_people = repo.GetAll().ToList());
                if (_people == null)
                {
                    _people = new List<Person>();
                    var peop = repo.GetAll();
                    if (peop != null && peop.Count() > 0)
                    {
                        _people = peop.ToList();
                    }
                }
                return _people;
            }
            set => _people = value;
        }

        public AddItemPageViewModel()
        {
            Title = "Add Item Page";
            repo = new PersonRepository();
        }

        public Boolean AddEntry()
        {
            EntryErrors = string.Empty;

            if (string.IsNullOrEmpty(FirstNameEntry))
            {
                EntryErrors += "First name cannot be empty";
            }
            if (string.IsNullOrEmpty(LastNameEntry))
            {
                EntryErrors += "Last name cannot be empty";
            }
            if (string.IsNullOrEmpty(PhoneNumberEntry))
            {
                EntryErrors += "Phone number cannot be empty";
            }
            if (EntryErrors == string.Empty)
            {
                Person person = new Person()
                {
                    FirstName = FirstNameEntry,
                    LastName = LastNameEntry,
                    PhoneNumber = PhoneNumberEntry
                };

                if (People.Count() > 0)
                {
                    person.Id = Math.Max(People.Max(p => p.Id), 0) + 1;
                }
                else
                {
                    person.Id = 1;
                }
                People.Add(person);
                repo.Save(People);
                return true;
            }
            return false;
        }


    }
}
