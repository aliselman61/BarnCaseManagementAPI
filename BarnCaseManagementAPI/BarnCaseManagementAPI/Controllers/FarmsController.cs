using BarnCase.Application.Interfaces;
using BarnCase.Application.Services;
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
    public IActionResult CreateFarm(int userId, string farmName)
    {
        var farmId = _farmService.CreateFarm(userId, farmName);
        return Ok(new { FarmId = farmId });
    }
}
