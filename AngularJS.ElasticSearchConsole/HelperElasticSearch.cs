using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.ElasticSearch;
using Elasticsearch.Net;
using Nest;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;

namespace AngularJS.ElasticSearchConsole
{
    public class HelperElasticSearch
    {
        private ElasticClient client;

        public ElasticClient Client
        {
            get
            {
                if (client == null)
                    ConfigureElasticClient();

                return client;

                //return ElasticSearchManager.Instance;
            }
        }

        public void ConfigureElasticClient()
        {
            //var setting = new ConnectionSettings(new Uri("http://localhost:9200/"),Constants.INDEX_PERSON);
            //setting.EnableTrace();
            //setting.ExposeRawResponse();
            //client = new ElasticClient(setting);

            var node = new Uri(Constants.ELASTIC_SEARCH_URI);

           var settings = new ConnectionSettings(node);
            settings.SetDefaultIndex(Constants.INDEX_PERSON);
            settings.MapDefaultTypeNames(m => m.Add(typeof(Person), (Constants.INDEX_PERSON)));

            client = new ElasticClient(settings);

            client.CreateIndex(ci => ci
                .Index(Constants.INDEX_PERSON)
                .AddMapping<Person>(m => m.MapFromAttributes()));
        }

        public void PopulateIndexPerson()
        {
            //Client.CreateIndex(ci => ci
            //    .Index(Constants.INDEX_PERSON)
            //    .AddMapping<Person>(m => m.MapFromAttributes()));

            for (var i = 0; i < 20; i++)
            {
                var index = i + 1;
                var person = new Person
                {
                    Id = index,
                    Name = string.Format("Person {0}", index),
                    Revenue = index*100000,
                    Comment = string.Format("comment {0}", index)
                };

                //Client.Index(person);
                //index a document under /myindex/mytype/1
                Client.Index(person);
                //Client.Raw.IndicesCreate(Constants.INDEX_PERSON);

            }
        }
    }
}
