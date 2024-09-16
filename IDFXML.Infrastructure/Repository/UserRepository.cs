using IDFXML.Application.Interfaces;
using IDFXML.Domain;
using IDFXML.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IDFXML.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public async Task<User?> GetUserByFullNameAndEmail(string userFullName, string userEmail)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.FullName == userFullName && u.Email == userEmail);
        }
        
        public async Task AddUser(User userModel)
        {
            if(userModel is not null)
            {
                await _db.Users.AddAsync(userModel);
                await _db.SaveChangesAsync();
            };
        }

    }
}
