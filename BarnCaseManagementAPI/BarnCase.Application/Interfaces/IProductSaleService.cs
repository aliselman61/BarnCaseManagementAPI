namespace BarnCase.Application.Interfaces;

public interface IProductSaleService
{
    void SellProduct(Guid userId, Guid productId);
}
