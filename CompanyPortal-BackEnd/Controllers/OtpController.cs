using Application.DTO_S.Otp;
using Application.DTO_S.SendOtpDto.cs;
using Microsoft.AspNetCore.Mvc;
using Application.Services.IService;

namespace CompanyPortal_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpDto dto)
        {
            await _otpService.SendOtpAsync(dto.Email);
            return Ok("OTP Sent.");
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            var result = await _otpService.VerifyOtpAsync(dto.Email, dto.Code);
            return result ? Ok("OTP Verified.") : BadRequest("Invalid or expired OTP.");
        }
    }
}
