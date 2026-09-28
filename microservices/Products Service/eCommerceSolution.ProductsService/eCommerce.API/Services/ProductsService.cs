using eCommecre.Infrastructre.Repository_Interfaces;
using eCommerce.Core.Entities;

namespace eCommerce.API.Services
{
    public class ProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Product? GetProduct(Guid id)
        {
            return _productsRepository.GetProductByCondition(p => p.ProductID == id);
        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            return _productsRepository.GetProducts();
        }
        public void AddProduct(Product product)
        {
            _productsRepository.AddProduct(product);
        }
        public void DeleteProduct(Guid id)
        {
            _productsRepository.DeleteProduct(id);
        }
        public void UpdateProduct(Product product)
        {
            _productsRepository.UpdateProduct(product);
        }



    }
}
