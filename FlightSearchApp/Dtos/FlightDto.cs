namespace FlightSearchApp.Dtos;

public class FlightDto
{
    public string FlightNumber { get; set; }
    public string Carrier { get; set; }
    public string OriginCityName { get; set; }
    public string OriginCountry { get; set; }
    public string DestCityName { get; set; }
    public string DestCountry { get; set; }
    public DateTime Timestamp { get; set; }
    public bool FlightDelay { get; set; }
    public int FlightDelayMin { get; set; }
    public bool FlightCancelled { get; set; }
    public float FlightTimeMin { get; set; }
    public double DistanceKilometers { get; set; }
    public string OriginWeather { get; set; }
    public double AvgTicketPrice { get; set; }
}
