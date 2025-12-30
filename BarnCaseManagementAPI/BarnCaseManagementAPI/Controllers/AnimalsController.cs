using BarnCase.Application.Interfaces;
using BarnCaseManagementAPI.Models;
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
    public IActionResult BuyAnimal([FromBody] BuyAnimalDto dto)
    {
        var animal = _animalService.BuyAnimal(
            dto.FarmId,
            dto.Name,
            dto.Type,
            dto.Age,
            dto.Price
        );

        return Ok(new
        {
            animal.Id,
            animal.Name,
            animal.Type,
            animal.Age,
            animal.Price,
            animal.FarmId
        });
    }

    
    [HttpGet("{animalId:guid}")]
    public IActionResult GetById(Guid animalId)
    {
        var animal = _animalService.GetById(animalId);
        return Ok(animal);
    }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        var animals = _animalService.GetAll();
        return Ok(animals);
    }

    
    [HttpPut("{animalId:guid}")]
    public IActionResult UpdatePrice(Guid animalId, [FromBody] decimal price)
    {
        var animal = _animalService.UpdateAnimal(animalId, price);
        return Ok(animal);
    }

    
    [HttpDelete("{animalId:guid}")]
    public IActionResult Delete(Guid animalId)
    {
        _animalService.DeleteAnimal(animalId);
        return NoContent();
    }
}
