using CRUD.Models;
using CRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {
        private readonly IOrderListRepository _orderListRepository;
        public OrderListController(IOrderListRepository orderListRepository)
        {
            _orderListRepository = orderListRepository;
        }


        [HttpGet]
        public async Task<List<OrderList>> GetOrders()
        {
            return await _orderListRepository.GetOrders();

        }

        [HttpPost]
        public async Task<ActionResult<OrderList>> AddOrder([FromBody] OrderList orderList)
        {
            if (orderList == null)
            {
                return BadRequest("Invalid State");

            }
            return await _orderListRepository.AddOrders(orderList);
        }
        [HttpPut]
        public async Task<ActionResult<OrderList>> UpdateOrder([FromBody] OrderList orderList)
        {
            if (orderList == null)
            {
                return BadRequest("Invalid State");
            }
            return await _orderListRepository.UpdateOrder(orderList);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderList>> DeleteOrder(int id)
        {
            return await _orderListRepository.DeleteOrder(id);
        }
    }
}
