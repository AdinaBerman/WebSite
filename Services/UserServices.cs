using Entities;
using Repository;
using Resorces;


namespace Services
{ 
    public class UserServices : IUserService
    {
        private readonly IRepository repository;
        public int checkPassword (string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }


        public User addUser(User user)
        {
            //Task, await?? 
            int res = checkPassword(user.Password);
            if(res >= 2)
                repository.addUser(user);
            else return null;
            return user;
            //return the newCreatedUser - returned from repository.addUser(user) 
            //clean code- if res<2 return null, return repository.addUser(user);
        }
        public async Task<User> update(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res >= 2)
                return await repository.update(id, user);
            //unnecessary else
            else return null;
        }

        public async Task<User> GetUserByUsarNameAndPassword(string userName, string password)
        {
            return await repository.GetUserByUsarNameAndPassword(userName, password);
        }

        public async Task<User> getUserById(int id)
        {
            return await repository.getUserById(id);
        }

    }
}