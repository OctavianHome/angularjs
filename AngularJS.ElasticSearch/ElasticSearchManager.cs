using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS.ElasticSearch
{
    public class ElasticSearchManager
    {
        private Lazy<ElasticClient> _ourAwesomeObject = new Lazy<ElasticClient>(() =>
        {
            var setting = new ConnectionSettings(new Uri("http://localhost:9200"));
            //setting.SetDefaultIndex("musicstore");
            return new ElasticClient(setting);
        });

        public ElasticClient OurAwesomeObject
        {
            get { return _ourAwesomeObject.Value; }
        }
    }
}
