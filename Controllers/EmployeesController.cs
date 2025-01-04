using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IBusinessLogic _businessLogic;

        public EmployeesController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }
        [HttpGet("GetEmployees")]
        
        public async Task<EmployeesModel?>GetEmployees(CancellationToken cancelationToken)
        {
            return await _businessLogic.GetEmployees(cancelationToken);
        }

        [HttpPost("sendingtoDB")]

        public async Task<int> SaveEmployee(string FirstName, string LastName, string Notes,string Photo, CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveEmployee(FirstName, LastName,Notes,Photo, cancellationToken);
        }

    }
}
