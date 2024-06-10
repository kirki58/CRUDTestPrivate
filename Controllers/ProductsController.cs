using CRUDTest.DataAccess.Repositories;
using CRUDTest.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTest.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO product)
    {
        try
        {
            await _productRepository.Create(product);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateProductDTO product)
    {
        try
        {
            await _productRepository.Update(id, product);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _productRepository.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
        try
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
