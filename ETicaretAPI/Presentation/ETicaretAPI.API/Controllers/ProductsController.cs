using ETicaretAPI.Application;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IReadProductRepository _readProductRepository;
        readonly private IWriteProductRepository _writeProductRepository;
        readonly private IWriteOrderRepository _writeOrderRepository;
        readonly private IWriteCustomerRepository _writeCustomerRepository;

        public ProductsController(
            IWriteProductRepository writeProductRepository, 
            IReadProductRepository readProductRepository,
            IWriteOrderRepository writeOrderRepository,
            IWriteCustomerRepository writeCustomerRepository
        )
        {
            _writeProductRepository = writeProductRepository;
            _readProductRepository = readProductRepository;
            _writeOrderRepository = writeOrderRepository;
            _writeCustomerRepository = writeCustomerRepository;
        }

        [HttpGet]
        public async Task Get() 
        {           

            await _writeOrderRepository.AddAsync(new()
            {
              Id = Guid.NewGuid(),
              Description = "Deneme Açıklama",
              Address = "Deneme Adres",
              CustomerId = Guid.Parse("F82F68E7-03B9-4238-9AFB-FDD8AB064D32")  
            });
            await _writeOrderRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product result = await _readProductRepository.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
