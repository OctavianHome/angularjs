using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.Model.Model;
using AngularJS.Repository.Generic;

namespace AngularJS.Repository.Repository
{
    public class PersonRepository : IPersonRepository
    {
       
        private List<Person> personsList = new List<Person>();
        private int _nextId = 1;

        public PersonRepository()
        {
            //Add products for the Demonstration
           Add(new Person { Name = "Person1", Revenue = 100000, Comment = "comments 1" });
           Add(new Person { Name = "Person2", Revenue = 200000, Comment = "comments 2" });
            Add(new Person { Name = "Person3", Revenue = 300000, Comment = "comments 3" });
            Add(new Person { Name = "Person4", Revenue = 400000, Comment = "comments 4" });
        }

        public IEnumerable<Person> GetAll()
        {
            return personsList;
        }

        public Person Get(int id)
        {
            // TO DO : Code to find a record in database
            return personsList.Find(p => p.Id == id);
        }
        public Person Add(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            item.Id = _nextId++;
            personsList.Add(item);
            return item;
        }

        public Person Edit(int personId)
        {
            return personsList.FirstOrDefault(x => x.Id == personId);
        }

        public void Edit(Person item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            int index = personsList.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return ;
            }
            personsList.RemoveAt(index);
            personsList.Add(item);
        }
        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            personsList.RemoveAll(p => p.Id == id);
            return true;
        }

        public IEnumerable<Person> FindBy(System.Linq.Expressions.Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Person Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
