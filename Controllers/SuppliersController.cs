using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        private readonly IBusinessLogic _businessLogic;

        public SuppliersController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpGet("GetSuppliers")]

        public async Task<SuppliersModel?> GetShippers(CancellationToken cancellation)
        {
            return await _businessLogic.GetSuppliers(cancellation);
        }

        [HttpPost("postingSuppliers")]

        public async Task<int> SaveSuppliers(string SupplierName, string ContactName, string Address, string City, string PostalCode, string Country, string Phone,CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveSuppliers(SupplierName, ContactName, Address, City, PostalCode, Country, Phone);
        }
      
    }
}
