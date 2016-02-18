using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.ElasticSearch;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;

namespace AngularJS.ElasticSearchConsole
{
    public class HelperPlainElasticSearch
    {
        private ElasticConnection _plainClient;
        private JsonNetSerializer _serializer;

        public ElasticConnection PlainClient
        {
            get
            {
                if (_plainClient == null)
                    ConfigurePlainElasticClient();

                return _plainClient;
            }
        }

        public JsonNetSerializer Serializer
        {
            get
            {
                if (_serializer == null)
                    _serializer = new JsonNetSerializer();

                return _serializer;
            }
        }

        private void ConfigurePlainElasticClient()
        {
            _plainClient = new ElasticConnection("localhost");
        }

        public void PopulatePlainIndexPerson()
        {
            for (var i = 20; i < 40; i++)
            {
                var index = i + 1;
                var person = new Person
                {
                    Id = index,
                    Name = string.Format("Person {0}", index),
                    Revenue = index * 100000,
                    Comment = string.Format("comment {0}", index)
                };

                var personJson = Serializer.ToJson(person);
                var result = PlainClient.Put(new IndexCommand(Constants.INDEX_PERSON, "person", id: index.ToString()), personJson);
            }
        }
    }
}
