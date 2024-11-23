using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using register_caborno.Models.Dtos;
using register_caborno.Services;

namespace register_caborno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;  // Usando a interface IActivityService

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null) return NotFound("Activity not found.");

            return Ok(activity);
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ActivityDto activityDto)
        {
            var result = await _activityService.RegisterAsync(activityDto);
            if (!result)
                return BadRequest("Error registering the activity.");

            return Ok("Activity registered successfully!");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] ActivityDto activityDto)
        {
            var result = await _activityService.UpdateActivityAsync(id, activityDto);
            if (!result)
                return NotFound("Activity not found to update.");

            return Ok("Activity updated successfully.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var result = await _activityService.DeleteActivityAsync(id);
            if (!result)
                return NotFound("Activity not found to delete.");

            return Ok("Activity deleted successfully.");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activityService.GetAllActivityAsync();
            return Ok(activities);
        }
    }
}
