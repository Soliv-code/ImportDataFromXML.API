using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByFullNameAndEmail(string UserFullName, string UserEmail);
        Task AddUser(User userModel);
    }
}
