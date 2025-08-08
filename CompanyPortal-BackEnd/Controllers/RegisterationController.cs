using Application.DTO_S;
using Application.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyPortal_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterationController(IRegisterService RegisterService)
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
                var userId = await _registerService.RegisterCompanyAsync(createCompanyDto);

                return Ok(new
                {
                    message = "Company registered successfully.",
                    userId = userId
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Email already exists"))
                    return BadRequest("Email already exists");

                return BadRequest("Something went wrong");
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
                
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

    }
}
