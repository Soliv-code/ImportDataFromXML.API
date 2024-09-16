using IDFXML.Application.Interfaces;
using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _ur;
        public UserService(IUserRepository userRepository)
        {
            _ur = userRepository;
        }
        public async Task AddUser(User userModel)
        {
            await _ur.AddUser(userModel);
            return;
        }
        public async Task<User?> GetUserByFullNameAndEmail(string UserFullName, string UserEmail)
        {
            return await _ur.GetUserByFullNameAndEmail(UserFullName, UserEmail);
        }
    }
}
