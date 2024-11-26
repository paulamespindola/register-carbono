using Microsoft.EntityFrameworkCore;
using register_caborno.Data;
using register_caborno.Models;
using register_caborno.Models.Dtos;

namespace register_caborno.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _context;

        public ActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(ActivityDto activityDto)
        {
            var activity = new Activity
            {
                Descricao = activityDto.Descricao,
                EmissoesCO2 = activityDto.EmissoesCO2,
                DataRegistro = activityDto.DataRegistro != default ? activityDto.DataRegistro : DateTime.Now,
                EhReducao = activityDto.EhReducao,
                UserId = activityDto.UserId,
            };

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateActivityAsync(int id, ActivityDto activityDto)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return false;

            activity.Descricao = activityDto.Descricao ?? activity.Descricao;
            activity.EmissoesCO2 = activityDto.EmissoesCO2 != 0 ? activityDto.EmissoesCO2 : activity.EmissoesCO2;

            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActivityAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return false;

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ActivityDto> GetActivityByIdAsync(int id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
            if (activity == null) return null;

            return new ActivityDto
            {
                Descricao = activity.Descricao,
                EmissoesCO2 = activity.EmissoesCO2,
                UserId = activity.UserId,
            };
        }

        public async Task<List<ActivityDto>> GetAllActivityAsync()
        {
            return await _context.Activities.Select(a => new ActivityDto
            {
                Descricao = a.Descricao,
                EmissoesCO2 = a.EmissoesCO2,
                UserId = a.UserId,
            }).ToListAsync();
        }
    }
}
