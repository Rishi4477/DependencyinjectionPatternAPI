using APIModels;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyinjectionPatternAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IBusinessLogic _businessLogic;
        public CategoriesController(IBusinessLogic businessLogic) {
        
        _businessLogic = businessLogic;
        
        }

        [HttpGet("GetAllCategories")]
        public async Task<CategoryModel?> GetCategory(CancellationToken cancellationToken)
        {
            return await _businessLogic.GetCategories(cancellationToken);
        }

        [HttpPost("SaveCategories")]
        public async Task<bool?> SaveCategories([FromQuery]string categoryName, [FromQuery] string categoryDescription, CancellationToken cancellationToken)
        {
            return await _businessLogic.SaveCategories(categoryName, categoryDescription,cancellationToken);
        }
        [HttpGet("GetCatgoriesById")]

        public async Task<CategoryModel?> GetCategories([FromQuery] int iCategoryID,CancellationToken cancellationToken)
        {
            return await _businessLogic.GetCategories(iCategoryID, cancellationToken);
        }
    }   
}
 