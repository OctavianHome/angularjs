using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace AngularJS.ElasticSearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new HelperPlainElasticSearch();
            helper.PopulatePlainIndexPerson();

            //var helper = new HelperElasticSearch();
            //helper.PopulateIndexPerson();

            //var allResponse = helper.Client.Search<Person>(s => s
            //   .AllIndices()
            //   .AllTypes()
            //   );

            //var response = helper.Client.Search<Person>(s => s
            //    .From(0)
            //    .Size(1000)
            //    .Query(q =>
            //        q.Term(t => t.Name, "Person 3")
            //    )
            //    );

            //SearchDescriptor<Person> searchDescriptor = new SearchDescriptor<Person>().From(0).Size(100000).Query(q => q.Term(x => x.Name, "Person 256"));
            //var searchResponse = helper.Client.Search<Person>(searchDescriptor);
            ////var dslresult = Encoding.UTF8.GetString(Client.Serializer.Serialize(searchDescriptor));

            //QueryContainer query = new TermQuery
            //{
            //    Field = "Name",
            //    Value = "256"
            //};

            //var searchRequest = new SearchRequest<Person>
            //{
            //    From = 0,
            //    Size = 100,
            //    Query = query
            //};
            //ISearchResponse<Person> searchResponseIS = helper.Client.Search<Person>(searchRequest);
            //string dslresultIS = Encoding.UTF8.GetString(_client.Serializer.Serialize(searchRequest));

            //var response = Client.Get<Person>(1, idx => idx.Index(INDEX_PERSON)); // returns an IGetResponse mapped 1-to-1 with the Elasticsearch JSON response
            //var p = response.Source; // the original document
        }
    }
}
