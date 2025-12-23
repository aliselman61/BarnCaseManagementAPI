namespace BarnCase.Application.Interfaces;

public interface IProductSaleService
{
    void SellProduct(int userId, int productId);
}
