using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> addUserAsync(User user);
        Task<User> GetUserByUsarNameAndPasswordAsync(string userName, string password);
        Task<User> updateAsync(int id, User userUpdate);
        Task<User> getUserByIdAsync(int id);
    }
}
