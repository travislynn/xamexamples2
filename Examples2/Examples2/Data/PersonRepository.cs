using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples2.Model;

namespace Examples2.Data
{
    public class PersonRepository : GenericFileRepository<Person>
    {
        public PersonRepository() : base("PersonFile.json")
        {
        }
    }
}
