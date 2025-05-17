using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InventoryManagement.DTOs;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            var productDto = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productService.AddProductAsync(productDto);
            var createdProductDto = _mapper.Map<ProductDTO>(createdProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProductDto.Id }, createdProductDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }
            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _productService.UpdateProductAsync(id, productDto);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            var updatedProductDto = _mapper.Map<ProductDTO>(updatedProduct);
            return Ok(updatedProductDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string? name, [FromQuery] string? category)
        {
            var products = await _productService.SearchProductsAsync(name, category);
            return Ok(products);

        }
    }
}

        
    