using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        int checkPassword(string password);
        Task<User> addUserAsync(User user);
        Task<User> GetUserByUsarNameAndPasswordAsync(string userName, string password);
        Task<User> getUserByIdAsync(int id);
        Task<User> updateAsync(int id, User user);
    }
}
