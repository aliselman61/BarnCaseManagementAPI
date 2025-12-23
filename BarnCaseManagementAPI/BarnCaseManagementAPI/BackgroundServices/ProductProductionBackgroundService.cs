using BarnCase.Application.Interfaces;
 
namespace BarnCaseManagementAPI.BackgroundServices;

public class ProductProductionBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ProductProductionBackgroundService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            productService.ProduceProducts();

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
