using BarnCase.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarnCaseManagementAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductSalesController : ControllerBase
{
    private readonly IProductSaleService _saleService;

    public ProductSalesController(IProductSaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpPost("sell")]
    public IActionResult SellProduct(int userId, int productId)
    {
        _saleService.SellProduct(userId, productId);
        return Ok("Product sold successfully");
    }
}
