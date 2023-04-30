using ETicaretAPI.Application;
using ETicaretAPI.Application.ViewModels.Product;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IReadProductRepository _readProductRepository;
        readonly private IWriteProductRepository _writeProductRepository;

        public ProductsController(
            IWriteProductRepository writeProductRepository, 
            IReadProductRepository readProductRepository
        )
        {
            _writeProductRepository = writeProductRepository;
            _readProductRepository = readProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_readProductRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _readProductRepository.GetByIdAsync(id, false);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductVM productVM)
        {
            await _writeProductRepository.AddAsync(new()
            {
                Name = productVM.Name,
                Price = productVM.Price,
                Stock = productVM.Stock,
            });
            await _writeProductRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductVM productVM)
        {
            Product product = await _readProductRepository.GetByIdAsync(productVM.Id);
            product.Name = productVM.Name;
            product.Price = productVM.Price;
            product.Stock = productVM.Stock;
            await _writeProductRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Product product = await _readProductRepository.GetByIdAsync(id);
            await _writeProductRepository.RemoveAsync(id);
            await _writeProductRepository.SaveAsync();
            return Ok();
        }


    }
}
