using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase{
    private readonly UpdateAccountOrchestrator _updateAccount;
    private readonly UpdateAccountAdminOrchestrator _updateUserAdmin;
    private readonly IGetUserByIdUseCase _getUserById;
    private readonly IDeleteUserByIdUseCase _deleteUserById;

    [Authorize(Roles ="ADMIN")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute]long id){
        return StatusCode(200,await _getUserById.Execute(id));
    }

    [HttpPut]
    [Authorize(Roles ="USER,ADMIN")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateAccountUserRequestDto dto){
        return StatusCode(200,await _updateAccount.Execute(dto)); 
    }

    [Authorize(Roles="ADMIN")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAdmin([FromBody] UpdateAccountUserAdminRequestDto dto,[FromRoute] long id){
        await _updateUserAdmin.Execute(id,dto);
        return StatusCode(204);
    }

    [Authorize(Roles ="ADMIN")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById([FromRoute] long id){
        await _deleteUserById.Execute(id);
        return StatusCode(204); 
    }

}