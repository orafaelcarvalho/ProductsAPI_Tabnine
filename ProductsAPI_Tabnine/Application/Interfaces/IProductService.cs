using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI_Tabnine.Domain.Entities;

namespace ProductsAPI_Tabnine.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}