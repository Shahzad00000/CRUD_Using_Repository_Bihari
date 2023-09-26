using CRUD_Using_Repository_Bihari.Models;

namespace CRUD_Using_Repository_Bihari.Repository.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers(); 
        Task<int>AddUser(User user);
        Task<User > GetUserById(int id);   
        Task<bool> UpdateRecord(User user);
        Task<bool> DeleteRecord(int id);
    }
}
