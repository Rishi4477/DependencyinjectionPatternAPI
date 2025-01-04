using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("UserLogin/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        private readonly IBusinessLogic _businessLogic;

        public UserLoginController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [HttpGet("GetValidUser")]

        public async Task<UsersModel?> GetValidUser([FromQuery] string StruserName,[FromQuery]string strPassword,CancellationToken cancellation )
        {
            return await _businessLogic.GetUsersbyidandpsw(StruserName, strPassword, cancellation);
        }

        [HttpGet("GetUserExist")]
        public async Task<bool?> GetUserExist([FromQuery] string UserName,CancellationToken cancellationToken)
        {
            return await _businessLogic.GetUserExist(UserName, cancellationToken);
        }

    }
}
