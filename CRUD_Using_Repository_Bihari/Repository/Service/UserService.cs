using CRUD_Using_Repository_Bihari.Context;
using CRUD_Using_Repository_Bihari.Models;
using CRUD_Using_Repository_Bihari.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD_Using_Repository_Bihari.Repository.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var Data = await _context.Users.ToListAsync();
            return Data;
        }
        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }
        public async Task<User> GetUserById(int Id)
        {
            var Data = await _context.Users.Where(x => x.UserId == Id).FirstOrDefaultAsync();
            return Data;
        }

        //public async Task<bool> UpdateRecord(User user)
        //{
        //    bool status = false;
        //    if (user != null)
        //    {
        //        _context.Users.Update(user);
        //        await _context.SaveChangesAsync();
        //        status = true;
        //    }
        //    return status;
        //}
        public async Task<bool> UpdateRecord(User user)
        {
            if (user == null)
            {
                return false; // User is null, so we can't update anything
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRecord(int id)
        {
            bool status = false;
            if(id != 0)
            {
                var Data=await _context.Users.Where(x=>x.UserId == id).FirstOrDefaultAsync();   
                if(Data != null)
                {
                    _context.Users.Remove(Data);
                    await _context.SaveChangesAsync(); 
                    status = true;
                }
            }
            return status;
        }
    }
}
