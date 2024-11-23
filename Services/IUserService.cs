using register_caborno.Models.Dtos;

namespace register_caborno.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegisterDto userDto);
        Task<UserDto> LoginAsync(UserLoginDto userDto); // Alterado de UserLoginDto para UserDto
        Task<bool> UpdateUserAsync(int id, UserUpdateDto userUpdateDto);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<List<ActivityDto>> GetActivitiesByUserAsync(int userId);
    }

}
