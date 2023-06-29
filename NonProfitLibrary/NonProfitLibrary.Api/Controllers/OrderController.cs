using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProfitLibrary.Api.Models;
using NonProfitLibrary.Api.Models.Services;
using NonProfitLibrary.Common.Models;

namespace NonProfitLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly OrderService _orderService;

        public OrderController(ApplicationContext db)
        {
            _db = db;
            _orderService = new OrderService(db);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            return await _orderService.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderService.GetById(id);
            return order== null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderModel orderModel)
        {
            if(orderModel != null)
            {
                var result = _orderService.Create(orderModel);
                return result ? Ok(result) : NotFound();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] OrderModel orderModel) 
        {
            if(orderModel !=null)
            {
                bool result = _orderService.Update(id, orderModel);
                return result ? Ok(result) : NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _orderService.Delete(id);
            return result ? Ok(result) : NotFound();
        }

        [HttpPatch("{id}/bookOnOrder")]
        public IActionResult AddNewBookToOrder(int id, [FromBody] List<int> bookOnOrderIds)
        {
            if(bookOnOrderIds != null)
            {
                _orderService.AddBookToOrder(id, bookOnOrderIds);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{id}/bookOnOrder/remove")]
        public IActionResult RemoveNewBookFromOrder(int id, [FromBody] List<int> bookOnOrderIds)
        {
            if (bookOnOrderIds != null)
            {
                _orderService.RemoveBookFromOrder(id, bookOnOrderIds);
                return Ok();
            }
            return BadRequest();
        }
    }
}
