using CINEMA.Data;
using CINEMA.Models;
using CINEMA.Repositories.IRepositories;

namespace CINEMA.Repositories
{
    public class UserOTPRepository : Repository<UserOTP>, IUserOTPRepository
    {
        private readonly ApplicationDbContext _context;

        public UserOTPRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
