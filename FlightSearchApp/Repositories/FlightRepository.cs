using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using FlightSearchApp.Dtos;
using FlightSearchApp.Models;
using System.Collections.Generic;

namespace FlightSearchApp.Repositories;

public class FlightRepository
{
    private readonly ElasticsearchClient _elasticsearchClient;
    public FlightRepository(ElasticsearchClient elasticsearchClient)
    {
        _elasticsearchClient = elasticsearchClient;
    }

    private string IndexName = "kibana_sample_data_flights"; 

    public async Task<(List<Flight> list, long count)> SearchAsync(FlightSearchDto flight, int page, int pageSize)
    {
        List<Action<QueryDescriptor<Flight>>> list = new();

        if (flight is null)
        {
            list.Add(q => q.MatchAll(m => m.QueryName("MatchAll")));
            return await CalculateResultSet(list, page, pageSize);
        }

        if (!string.IsNullOrEmpty(flight.OriginCityName))
        {
            list.Add(q => q.Match(m => m.Field(f => f.OriginCityName).Query(flight.OriginCityName)));

        }

        if (!string.IsNullOrEmpty(flight.OriginCountry))
        {
            list.Add(q => q.Match(m => m.Field(f => f.OriginCountry).Query(flight.OriginCountry)));

        }

        if (!string.IsNullOrEmpty(flight.DestCityName))
        {
            list.Add(q => q.Match(m => m.Field(f => f.DestCityName).Query(flight.DestCityName)));
        }

        if (!string.IsNullOrEmpty(flight.DestCountry))
        {
            list.Add(q => q.Match(m => m.Field(f => f.DestCountry).Query(flight.DestCountry)));
        }


       
        if (flight.MinTicketPrice.HasValue || flight.MaxTicketPrice.HasValue)
        {
            list.Add(q=>q.Range(r=>r.NumberRange(n=>n.Field(f=>f.AvgTicketPrice).Gte(flight.MinTicketPrice).Lte(flight.MaxTicketPrice))));
            
        }




        if (flight.FlightDelay.HasValue)
        {
            list.Add(q => q.Term(t => t.Field(f => f.FlightDelay).Value(flight.FlightDelay.Value)));
        }

        if (!list.Any())
        {
            list.Add(q => q.MatchAll(m => m.QueryName("MatchAllQuery")));
        }

        return await CalculateResultSet(list, page, pageSize);
    }

    private async Task<(List<Flight> list, long count)> CalculateResultSet(List<Action<QueryDescriptor<Flight>>> list, int page, int pageSize)
    {
       
        
            var result = await _elasticsearchClient.SearchAsync<Flight>(s => s
            .Index(IndexName)
            .Size(pageSize)
            .From((page - 1) * pageSize) 
            .Query(q => q.Bool(b => b.Must(list.ToArray())))
        );

            if (result.IsValidResponse && result.Hits != null)
            {
                var documents = result.Hits.Select(hit => hit.Source).ToList();
                return (documents, result.Total);
            }
            else
            {
                return (new List<Flight>(), 0); 
            }
        
        
    }
}

