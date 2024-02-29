using Domain.ViewEntity.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abtract;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder(CreateOrder createOrder)
        {
            await _orderServices
                .CreateOrder(createOrder, 
                HttpContext.User.FindFirst("Username").Value);
            return Ok();
        }
        [HttpGet("Detail")]
        public async Task<IActionResult> DetailOrder(int idOrder)
        {
            var rs = 
                await _orderServices
                .DetailOrder(HttpContext.User.FindFirst("Username").Value, idOrder);
            return Ok(rs);
        }
    }
}
