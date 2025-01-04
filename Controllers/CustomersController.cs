using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //private readonly BsinessLogic _bsinessLogic;

        //public CustomersController(BsinessLogic bsinessLogic)
        //{
        //    _bsinessLogic = bsinessLogic;
        //}
        //[HttpGet("GetAllCustomers")]

        //public async Task<CustomersModel?>GetCustomers(CancellationToken cancellation)
        //{
        //    return await _bsinessLogic.GetCustomers(cancellation);
        //}

        private readonly IBusinessLogic _businessLogic;

        public CustomersController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        [HttpGet("GetCustomers")]

        public async Task<IEnumerable<CustomersModel?>> GetCustomers(CancellationToken cancelationToken)
         {
            return await _businessLogic.GetCustomers(cancelationToken);
        }


        [HttpPost("SaveCustomers")]

        public async Task<bool> SaveCustomers(
            [FromQuery]string CustomerName, [FromQuery] string ContactName, [FromQuery] string CoustmerAddress,[FromQuery] string City, [FromQuery] string PostalCode, [FromQuery] string Country, [FromQuery] string States, CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveCustomers(CustomerName, ContactName, CoustmerAddress, City, PostalCode, Country, States,cancellationToken);
        }
        [HttpGet("GetCustomersByID")]   

        public async Task<CustomersModel?> GetCustomersByID([FromQuery] int iCustomerID, CancellationToken cancellationToken)
        {
            return await _businessLogic.GetCustomers(iCustomerID, cancellationToken);
        }
    }
}
 