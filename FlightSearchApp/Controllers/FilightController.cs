using FlightSearchApp.Dtos;
using FlightSearchApp.Models;
using FlightSearchApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearchApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilightController : ControllerBase
{
    private readonly FlightService _flightService;

    public FilightController(FlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] SearchDto? searchDto)
    {
        var (flightList, totalCount, pageLinkCount) = await _flightService.SearchAsync(searchDto.FlightSearchDto,searchDto.Page,searchDto.PageSize);

        searchDto.List= flightList.ToList();
        searchDto.TotalCount= totalCount;
        searchDto.PageLinkCount= pageLinkCount;
        return Ok(searchDto);

    }
}
