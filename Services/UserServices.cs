using Entities;
using Repositories;


namespace Services
{ 
    public class UserServices : IUserService
    {
        private readonly IRepository _repository;

        public UserServices(IRepository userRepository)
        {
            _repository = userRepository;
        }
        public int checkPassword (string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }


        public async Task<User> addUser(User user)
        {
            int res = checkPassword(user.Password);
            if (res < 2) 
                return null;
            return await _repository.addUser(user);
        }

        public async Task<User> update(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res >= 2)
                return await _repository.update(id, user);
            return null;
        }

        public async Task<User> GetUserByUsarNameAndPassword(string userName, string password)
        {
            return await _repository.GetUserByUsarNameAndPassword(userName, password);
        }

        public async Task<User> getUserById(int id)
        {
            return await _repository.getUserById(id);
        }

    }
}