using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Core.Entities;

namespace eCommecre.Infrastructre.Repository_Interfaces
{
    /// </summary>
    public interface IProductsRepository
    {
    /// <summary>
    /// 'GetProducts() - to retrieve all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    IEnumerable<Product> GetProducts();

    /// <summary>
    /// Gets a product by a specific condition.
    /// </summary>
    /// <param name="condition">The condition to filter products.</param>
    /// <returns>The product that matches the condition.</returns>
    Product GetProductByCondition(Func<Product, bool> condition);

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="product">The product to add.</param>
    void AddProduct(Product product);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="product">The product to update.</param>
    void UpdateProduct(Product product);

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    void DeleteProduct(int id);
}
}
