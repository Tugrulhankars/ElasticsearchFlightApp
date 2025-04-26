namespace FlightSearchApp.Dtos;

public class FlightSearchDto
{
    public string? OriginCityName { get; set; }
    public string? OriginCountry { get; set; }
    public string? DestCityName { get; set; }
    public string? DestCountry { get; set; }
    public double? MinTicketPrice { get; set; }
    public double? MaxTicketPrice { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? FlightDelay { get; set; }
    public bool? FlightCancelled { get; set; }
    public string? Carrier { get; set; }
}
