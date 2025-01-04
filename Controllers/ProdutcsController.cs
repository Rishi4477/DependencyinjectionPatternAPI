using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutcsController : ControllerBase
    {

        private readonly IBusinessLogic _businessLogic;

        public ProdutcsController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        [HttpGet("GetProducts")]

        public async Task<ProductsModel?>GetProducts(CancellationToken cancellation)
        {
            return await _businessLogic.GetProducts(cancellation);  
        }
    }
}
