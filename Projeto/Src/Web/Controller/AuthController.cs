using Microsoft.AspNetCore.Mvc;
using Src.Core.Application.Orchestrator;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase{

    private readonly CreateAccountOrchestrator _createAccount;
    private readonly LoginUserOrchestrator _loginAccountUser;

    [HttpPost]
    public async Task<IActionResult> CreateAccountUser([FromBody] CreateAccountUserRequestDto dto){
        return StatusCode(201,await _createAccount.Execute(dto));
    } 

    [HttpPost]
    public async Task<IActionResult> LoginAccountUser([FromBody] LoginUserDto dto){
        return StatusCode(200,await _loginAccountUser.Execute(dto));
    }
}