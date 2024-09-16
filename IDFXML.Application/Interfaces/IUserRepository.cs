using IDFXML.Domain;

namespace IDFXML.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByFullNameAndEmail(string UserFullName, string UserEmail);
        Task AddUser(User userModel);
    }
}
