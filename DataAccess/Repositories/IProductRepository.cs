using CRUDTest.DTOs;
using CRUDTest.Models.Domain;

namespace CRUDTest.DataAccess.Repositories;

public interface IProductRepository
{
    Task Create(CreateProductDTO product);
    Task Update(int id, CreateProductDTO product);
    Task Delete(int id);
    Task<List<Product>> GetAll();
    Task<Product?> GetById(int id);
}
