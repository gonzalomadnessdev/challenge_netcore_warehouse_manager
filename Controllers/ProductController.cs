using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using warehouse_manager.Application.Contracts;
using warehouse_manager.Application.Dtos;
using warehouse_manager.Repositories;
using warehouse_manager.Repositories.Models;

namespace warehouse_manager.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public ProductController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet("")]
        public IActionResult GetProducts()
        {
            var recordsList = _warehouseRepository.GetProductRecords();
            var result = new List<WarehouseEntry>();

            foreach (var item in recordsList) {
                result.Add(new WarehouseEntry() { ProductId = item.ProductId, Quantity = item.Quantity });
            }
            return Ok(result);
        }
    }
}
