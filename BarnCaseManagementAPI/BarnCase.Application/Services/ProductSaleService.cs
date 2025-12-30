using BarnCase.Application.Interfaces;
using BarnCase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarnCase.Application.Services
{
    public class ProductSaleService : IProductSaleService
    {
        private readonly BarnCaseDbContext _context;

        public ProductSaleService(BarnCaseDbContext context)
        {
            _context = context;
        }

        public void SellProduct(Guid userId, Guid productId)
        {
           
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
              throw new Exception("Product not found");

            user.Balance += product.Price;

            _context.Products.Remove(product);

            _context.SaveChanges();
        }
    }
}