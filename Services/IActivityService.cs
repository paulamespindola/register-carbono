using register_caborno.Models.Dtos;

namespace register_caborno.Services
{
    public interface IActivityService
    {
        Task<bool> RegisterAsync(ActivityDto activityDto);
        Task<bool> UpdateActivityAsync(int id, ActivityDto activityDto);
        Task<bool> DeleteActivityAsync(int id);
        Task<ActivityDto> GetActivityByIdAsync(int id);
        Task<List<ActivityDto>> GetAllActivityAsync();

    }
}
