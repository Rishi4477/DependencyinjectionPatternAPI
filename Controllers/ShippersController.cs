using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IBusinessLogic _businessLogic;

        public ShippersController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpGet("GetShippers")]

        public async Task<ShippersModel?>GetShippers(CancellationToken cancellation)
        {
            return await _businessLogic.GetShippers(cancellation);
        }
        [HttpPost("SaveShippers")]

        public async Task<bool?> SaveShippers(string shipperName, string shipperPhone, CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveShippers(shipperName, shipperPhone, cancellationToken);
        }
    }
}
