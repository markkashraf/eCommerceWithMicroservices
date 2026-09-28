using eCommecre.Infrastructre.DbContexts;
using eCommecre.Infrastructre.Repository_Interfaces;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommecre.Infrastructre.Repositories
{
  
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            } else {
                throw new ArgumentException("Product not found");
            }
        }

        public Product? GetProductByCondition(Func<Product, bool> condition)
        {
            var product = _context.Products.FirstOrDefault(condition);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if(existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Category = product.Category;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                _context.SaveChanges();
            }
        }
    }
}
