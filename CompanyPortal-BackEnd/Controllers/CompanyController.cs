using Application.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortal_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService )
        {
            _companyService = companyService;
        }


        [HttpGet("company-info/{userId}")]
        public async Task<IActionResult> GetCompanyInfo(string userId)
        {
            var result = await _companyService.GetCompanyInfoAsync(userId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
