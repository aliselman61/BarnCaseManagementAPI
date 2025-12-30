using BarnCase.Application.Interfaces;
using BarnCaseManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarnCaseManagementAPI.Controllers;

[ApiController]
[Route("api/farms")]
public class FarmsController : ControllerBase
{
    private readonly IFarmService _farmService;

    public FarmsController(IFarmService farmService)
    {
        _farmService = farmService;
    }

    
    [HttpPost]
    public IActionResult CreateFarm([FromBody] CreateFarmDto dto)
    {
        var farm = _farmService.CreateFarm(dto.Name, dto.UserId);

        return Ok(new
        {
            farm.Id,
            farm.Name,
            farm.UserId
        });
    }

    [HttpPut("{farmId:guid}")]
    public IActionResult UpdateFarm(Guid farmId, [FromBody] UpdateFarmDto dto)
    {
        var farm = _farmService.UpdateFarm(farmId, dto.Name);

        return Ok(new
        {
            farm.Id,
            farm.Name,
            farm.UserId
        });
    }

 
    [HttpGet]
    public IActionResult GetAll()
    {
        var farms = _farmService.GetAll();

        return Ok(farms.Select(f => new
        {
            f.Id,
            f.Name,
            f.UserId
        }));
    }

    
    [HttpGet("{farmId:guid}")]
    public IActionResult GetById(Guid farmId)
    {
        var farm = _farmService.GetById(farmId);

        return Ok(new
        {
            farm.Id,
            farm.Name,
            farm.UserId
        });
    }

    
    [HttpDelete("{farmId:guid}")]
    public IActionResult Delete(Guid farmId)
    {
        _farmService.DeleteFarm(farmId);
        return NoContent();
    }
}
