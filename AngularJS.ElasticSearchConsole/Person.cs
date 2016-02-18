using Nest;

namespace AngularJS.ElasticSearchConsole
{
    [ElasticType(Name = "PersonsNEST")]
    public class Person 
    {
        [ElasticProperty(Name = "_id", Index = FieldIndexOption.NotAnalyzed, Type = FieldType.String)]
        public int Id { get; set; }

        [ElasticProperty(Name = "name", Index = FieldIndexOption.Analyzed, Type = FieldType.String)]
        public string Name { get; set; }

        [ElasticProperty(Name = "revenue", Index = FieldIndexOption.Analyzed, Type = FieldType.String)]
        public decimal Revenue { get; set; }

        [ElasticProperty(Name = "comment", Index = FieldIndexOption.Analyzed, Type = FieldType.String)]
        public string Comment { get; set; }
    }
}
