using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository: IUserRepository
    {
        PruductsDbContext _pruductsDbContext;

        public UserRepository(PruductsDbContext pruductsDbContext)
        {
            _pruductsDbContext = pruductsDbContext;
        }

        public async Task<User> addUser(User user)
        {
            await _pruductsDbContext.Users.AddAsync(user);
            await _pruductsDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByUsarNameAndPassword(string userName, string password)
        {
            return await _pruductsDbContext.Users.Where(p => p.Email == userName && p.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> update(int id, User userUpdate)
        {
            userUpdate.UserId = id;

             var res=_pruductsDbContext.Users.Update(userUpdate);
            await _pruductsDbContext.SaveChangesAsync();
            return userUpdate;
        }

        public async Task<User> getUserById(int id)
        {
            return await _pruductsDbContext.Users.Where(p => p.UserId == id).FirstOrDefaultAsync();

        }

    } 
}