using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.Model.Model;
using AngularJS.Repository.Generic;
using AngularJS.ElasticSearch;
using Nest;

namespace AngularJS.Repository.Repository
{
    public class PersonRepository : IPersonRepository
    {
        const string INDEX_PERSON = "Persons";
        private List<Person> personsList = new List<Person>();
        private int _nextId = 1;
        //private ElasticClient client;

        private ElasticClient Client
        {
            get
            {
                //if (client == null)
                //    ConfigureElasticClient();

                //return client;

                return ElasticSearchManager.Instance;
            }
        }

        //private void ConfigureElasticClient()
        //{
        //    var setting = new ConnectionSettings(new Uri("http://localhost:9200"));
        //    client = new ElasticClient(setting);
        //}

        public PersonRepository()
        {
            // Add products for the Demonstration
            //Add(new Person { Name = "Person1", Revenue = 100000, Comment = "comments 1" });
            //Add(new Person { Name = "Person2", Revenue = 200000, Comment = "comments 2" });
            //Add(new Person { Name = "Person3", Revenue = 300000, Comment = "comments 3" });
            //Add(new Person { Name = "Person4", Revenue = 400000, Comment = "comments 4" });

            for (var i = 0; i < 20; i++)
            {
                //var name = @"Person{i}";
                //var comment= @"comments {i}";
                //Add(new Person { Name =string.Format("Person {0}",i), Revenue = i*100000, Comment =string.Format("comment {0}",i)});
                var person = new Person
                {
                    Name = string.Format("Person {0}", i),
                    Revenue = i*100000,
                    Comment = string.Format("comment {0}", i)
                };

                Client.Index(person);
            }

            var response = Client.Get<Person>(1, idx => idx.Index(INDEX_PERSON)); // returns an IGetResponse mapped 1-to-1 with the Elasticsearch JSON response
            var p = response.Source; // the original document
        }

        //private void CreateIndex()
        //{
        //    Client.IndexMany(personsList, INDEX_PERSON);
        //}

        private void TestQueryLow()
        {
            var query = new { query = new { term = new { Name = "Person 256" } } };
            //var json = Client.Serializer.Serialize(query).Utf8String();
        }

        private void TestQuery()
        {
            var allResponse = Client.Search<Person>(s => s
               .From(0)
               .Size(1000)
               );

            var response = Client.Search<Person>(s => s
                .From(0)
                .Size(1000)
                .Query(q =>
                    q.Term(t => t.Name, "Person 3")
                )
                );

            SearchDescriptor<Person> searchDescriptor = new SearchDescriptor<Person>().From(0).Size(100000).Query(q => q.Term(x => x.Name, "Person 256"));
            var searchResponse = Client.Search<Person>(searchDescriptor);
            //var dslresult = Encoding.UTF8.GetString(Client.Serializer.Serialize(searchDescriptor));

            QueryContainer query = new TermQuery
            {
                Field="Name",
                Value="256"
            };

            var searchRequest = new SearchRequest<Person>
            {
                From=0,
                Size=100,
                Query=query
            };
            ISearchResponse<Person> searchResponseIS = Client.Search<Person>(searchRequest);
            //string dslresultIS = Encoding.UTF8.GetString(_client.Serializer.Serialize(searchRequest));

        }

        public IEnumerable<Person> GetAll()
        {
            //CreateIndex();

            TestQuery();

            //var result = _client.Search<Person>(x => x.Query());

            // TO DO : Code to get the list of all the records in database

            //var result = ElasticSearchManager.Instance.Search<Person>(body => body.Filter(filter => filter.Term(x => x., genre.ToLower())).Take(1000));

            //var genreModel = new Person()
            //{
            //    Name = genre,
            //    Revenue = result.Documents.ToList()
            //};

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
