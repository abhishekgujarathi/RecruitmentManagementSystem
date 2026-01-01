using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagementSystem.API.Data;

namespace RecruitmentManagementSystem.API.Services
{
    public interface IReviewersService
    {
        Task<List<KeyValuePair<Guid, string>>> GetReviewersAsync();

    }
    public class ReviewersService:IReviewersService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReviewersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<KeyValuePair<Guid, string>>> GetReviewersAsync()
        {
            return await _context.Users
                .Where(u => u.IsActive && u.UserRole.RoleName == "Reviewer")
                .Select(u => new KeyValuePair<Guid, string>(
                    u.UserId,
                    u.Fname + " " + u.Lname
                ))
                .ToListAsync();
        }

    }
}
