using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using register_caborno.Data;
using register_caborno.Models;
using register_caborno.Models.Dtos;

namespace register_caborno.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto userDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == userDto.Email))
                return false;

            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
            };

            user.Password = _passwordHasher.HashPassword(user, userDto.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto> LoginAsync(UserLoginDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
            if (user == null ||
                _passwordHasher.VerifyHashedPassword(user, user.Password, userDto.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }

            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
     
            };
        }


        public async Task<bool> UpdateUserAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = userUpdateDto.Name ?? user.Name;
            user.Email = userUpdateDto.Email ?? user.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Activities).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;

            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Activities = user.Activities.Select(a => new ActivityDto
                {
                    Descricao = a.Descricao,
                    Emissao = a.Emissao
                }).ToList()
            };
        }

        public async Task<List<ActivityDto>> GetActivitiesByUserAsync(int userId)
        {
            var user = await _context.Users.Include(u => u.Activities).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return null;

            return user.Activities.Select(a => new ActivityDto
            {
                Descricao = a.Descricao,
                Emissao = a.Emissao
            }).ToList();
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users.Select(user => new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            }).ToListAsync();
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
