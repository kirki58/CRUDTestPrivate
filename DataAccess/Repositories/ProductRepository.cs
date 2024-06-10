using CRUDTest.DataAccess.DBC;
using CRUDTest.DTOs;
using CRUDTest.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUDTest.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public Task Create(CreateProductDTO product)
    {
        try
        {
            Product newProduct = new Product
            {
                Name = product.name,
                Price = product.price,
                Addition_Date = DateTime.Now,
                Updated_At = DateTime.Now
            };
            _context.Products.Add(newProduct);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected == 0)
            {
                throw new Exception("No rows affected");
            }
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task Delete(int id)
    {
        try
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _context.Products.Remove(product);
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected == 0)
            {
                throw new Exception("No rows affected");
            }
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<List<Product>> GetAll()
    {
        try
        {
            return Task.FromResult(_context.Products.ToList());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<Product?> GetById(int id)
    {
        try
        {
            return Task.FromResult(_context.Products.Find(id));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task Update(int id, CreateProductDTO product)
    {
        try
        {
            var productToUpdate = _context.Products.Find(id);
            if (productToUpdate == null)
            {
                throw new Exception("Product not found");
            }
            productToUpdate.Name = product.name;
            productToUpdate.Price = product.price;
            productToUpdate.Updated_At = DateTime.Now;
            int rowsAffected = _context.SaveChanges();
            if (rowsAffected == 0)
            {
                throw new Exception("No rows affected");
            }
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
