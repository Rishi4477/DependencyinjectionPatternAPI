using APIModels;
using BusinessLogic;
using EntityFrameWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("ShoppingCart/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBusinessLogic _businessLogic;

        public OrdersController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpGet("GetOrders")]

        public async Task<OrdersModel?>GetOrders(CancellationToken cancellation)
        {
            return await _businessLogic.GetOrders(cancellation);
        }
    }
}
