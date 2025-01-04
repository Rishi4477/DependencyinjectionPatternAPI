using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRegistartionController : ControllerBase
    {

        private readonly IBusinessLogic _businessLogic;

        public NewRegistartionController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpPost("SaveNewRegistartion")]

        public async Task<int?> SaveNewRegistartion([FromQuery]string Name, [FromQuery] string Email,[FromQuery] string MobileNumber, [FromQuery] string Password,CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveNewregistartion(Name, Email, MobileNumber, Password,cancellationToken);
        }
    }
}
