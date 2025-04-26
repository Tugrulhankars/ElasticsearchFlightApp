using Elastic.Clients.Elasticsearch;
using System.Text.Json.Serialization;

namespace FlightSearchApp.Models;

public class Flight
{
    [JsonPropertyName("FlightNum")]
    public string FlightNumber { get; set; }

    [JsonPropertyName("Carrier")]
    public string Carrier { get; set; }

    [JsonPropertyName("OriginCityName")]
    public string OriginCityName { get; set; }

    [JsonPropertyName("OriginCountry")]
    public string OriginCountry { get; set; }

    [JsonPropertyName("DestCityName")]
    public string DestCityName { get; set; }

    [JsonPropertyName("DestCountry")]
    public string DestCountry { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("FlightDelay")]
    public bool FlightDelay { get; set; }

    [JsonPropertyName("Cancelled")]
    public bool FlightCancelled { get; set; }

    [JsonPropertyName("FlightDelayMin")]
    public int FlightDelayMin { get; set; }

    [JsonPropertyName("FlightTimeMin")]
    public float FlightTimeMin { get; set; }

    [JsonPropertyName("DistanceKilometers")]
    public float DistanceKilometers { get; set; }

    [JsonPropertyName("DistanceMiles")]
    public float DistanceMiles { get; set; }

    [JsonPropertyName("OriginWeather")]
    public string OriginWeather { get; set; }

    [JsonPropertyName("AvgTicketPrice")]
    public float AvgTicketPrice { get; set; }

    [JsonPropertyName("OriginLocation")]
    public GeoLocation OriginLocation { get; set; }

    [JsonPropertyName("DestLocation")]
    public GeoLocation DestLocation { get; set; }
}
