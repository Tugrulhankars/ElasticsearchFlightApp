using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace FlightSearchApp;

public static class ElasticExtention
{
    public static void AddElastic(this IServiceCollection services)
    {
        var userName = "elastic";
        var password = "changeme";
        var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200")).Authentication(new BasicAuthentication(userName,password!));
        var client=new ElasticsearchClient(settings);

        services.AddSingleton(client);
    }
}
