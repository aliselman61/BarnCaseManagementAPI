using BarnCase.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarnCaseManagementAPI.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpPost("buy")]
    public IActionResult BuyAnimal(int userId, int farmId, string animalType)
    {
        _animalService.BuyAnimal(userId, farmId, animalType);
        return Ok("Animal purchased successfully");
    }
}
