using Application.DTO_S;
using Application.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortal_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public CompanyController(IRegisterService RegisterService)
        {
            _registerService = RegisterService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromForm] CreateCompanyDto createCompanyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _registerService.RegisterCompanyAsync(createCompanyDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("set-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetPassword([FromBody] CreatePasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var isCreated = await _registerService.CreatePassword(dto);

                if (isCreated)
                    return Ok(new { message = "Password created successfully." });

                return BadRequest("Password creation failed. Please check your data.");
            }
            catch (Exception ex)
            {
                // ممكن تحسّنها برسالة مخصصة أو لوجينج
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

    }
}
