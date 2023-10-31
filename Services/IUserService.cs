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
        User addUser(User user);
        Task<User> GetUserByUsarNameAndPassword(string userName, string password);
        Task<User> getUserById(int id);
        Task<User> update(int id, User user);
    }
}
