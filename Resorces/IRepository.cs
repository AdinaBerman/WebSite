using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        User addUser(User user);
        Task<User> GetUserByUsarNameAndPassword(string userName, string password);
        Task<User> update(int id, User userUpdate);
        Task<User> getUserById(int id);
    }
}
