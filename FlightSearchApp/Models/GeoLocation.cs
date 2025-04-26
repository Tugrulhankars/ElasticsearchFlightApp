using System.Text.Json.Serialization;

namespace FlightSearchApp.Models;

public class GeoLocation
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }
}
