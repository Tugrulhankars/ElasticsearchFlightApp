using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace FlightSearchApp;

public static class ElasticExtention
{
    public static void AddElastic(this IServiceCollection services)
    {
        var userName = "elastic";
        var password = "changeme";
        var elasticHost = Environment.GetEnvironmentVariable("ELASTICSEARCH_HOST")
                     ?? "http://localhost:9200"; // fallback
        var settings = new ElasticsearchClientSettings(new Uri(elasticHost)).Authentication(new BasicAuthentication(userName,password!));
        var client=new ElasticsearchClient(settings);

        services.AddSingleton(client);
    }
}
