using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/recovery")]
public class RecoveryPasswordController:ControllerBase{
    private readonly RecoveryPasswordOrchestrator _sendEmail;

    [HttpPost("send/email")]
    public async Task<IActionResult> SendEmailFromResetPassword(RecoveryPasswordDto dto){
        return StatusCode(200,await _sendEmail.Execute(dto));
    }
}