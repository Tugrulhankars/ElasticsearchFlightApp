using FlightSearchApp.Dtos;
using FlightSearchApp.Models;
using FlightSearchApp.Repositories;

namespace FlightSearchApp.Services;

public class FlightService
{
    private readonly FlightRepository _flightRepository;
    public FlightService(FlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<(List<FlightDto>,long totalCount,long pageLinkCount)> SearchAsync(FlightSearchDto flight,int page,int pageSize)
    {
        var (flightList, totalCount) = await _flightRepository.SearchAsync(flight,page, pageSize);
        var pageLinkCountCalculate = totalCount % pageSize;

        long pageLinkCount = 0;

        if (pageLinkCountCalculate == 0)
        {
            pageLinkCount = totalCount / pageSize;
        }
        else
        {
            pageLinkCount = (totalCount / pageSize) + 1;

        }


        var flightListDto = flightList.Select(x => new FlightDto()
        {
           AvgTicketPrice=x.AvgTicketPrice,
           Carrier=x.Carrier,
           DestCityName=x.DestCityName,
           DestCountry=x.DestCountry,
           DistanceKilometers = x.DistanceKilometers,
           FlightCancelled=x.FlightCancelled,
           FlightDelay=x.FlightDelay,
           FlightDelayMin=x.FlightDelayMin,
           FlightNumber=x.FlightNumber,
           FlightTimeMin=x.FlightTimeMin,
           OriginCityName=x.OriginCityName,
           OriginCountry=x.OriginCountry,
           OriginWeather=x.OriginWeather,
           Timestamp=x.Timestamp,



        }).ToList();

        return (flightListDto, totalCount, pageLinkCount);

    }
}
