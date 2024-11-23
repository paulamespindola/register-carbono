using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using register_caborno.Models.Dtos;
using register_caborno.Services;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService; 

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound("User not found.");

        return Ok(user);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
    {
        var updated = await _userService.UpdateUserAsync(id, userUpdateDto);
        if (!updated) return NotFound("User not found.");

        return Ok("User updated successfully.");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted) return NotFound("User not found.");

        return Ok("User deleted successfully.");
    }

    [Authorize]
    [HttpGet("{id}/activities")]
    public async Task<IActionResult> GetActivitiesByUser(int id)
    {
        var activities = await _userService.GetActivitiesByUserAsync(id);
        if (activities == null) return NotFound("User not found or no activities available.");

        return Ok(activities);
    }
}
