using Entities;
using Repositories;


namespace Services
{ 
    public class UserServices : IUserService
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public int checkPassword (string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }


        public async Task<User> addUserAsync(User user)
        {
            int res = checkPassword(user.Password);
            if (res < 2) 
                return null;
            return await _repository.addUserAsync(user);
        }

        public async Task<User> updateAsync(int id, User user)
        {
            int res = checkPassword(user.Password);
            if (res >= 2)
                return await _repository.updateAsync(id, user);
            return null;
        }

        public async Task<User> GetUserByUsarNameAndPasswordAsync(string userName, string password)
        {
            return await _repository.GetUserByUsarNameAndPasswordAsync(userName, password);
        }

        public async Task<User> getUserByIdAsync(int id)
        {
            return await _repository.getUserByIdAsync(id);
        }

    }
}