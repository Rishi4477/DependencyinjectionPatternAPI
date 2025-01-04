using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IBusinessLogic _businessLogic;

        public OrderDetailsController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        [HttpGet("getOrderDetails")]

        public async Task<OrderDetailModel?> GetOrderDetail(CancellationToken cancellation)
        {
            return await _businessLogic.GetOrderDetails(cancellation);
        }

        [HttpGet("GetOrderdetailsbyOrderIdandproductID")]

        public async Task<OrderDetailModel?> GetOrderdetailsbyOrderIdandproductID(int iOrderDetailid,CancellationToken cancellation)
        {
            return await _businessLogic.GetOrderdetailsbyOrderIdandproductID(iOrderDetailid,cancellation);
        }
    }

}
