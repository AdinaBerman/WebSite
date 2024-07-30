using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace TestProject_WebSite
{
    public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly PruductsDbContext _dbContex;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContex = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContex);
        }

        [Fact]
        public async Task GetUser_ValidCredentails_RetirnUser()
        {
            var email = "email@gmail.com";
            var password = "password";
            var user = new User { Email = email, Password = password, FirstName = "Test FN", LastName = "Test LN" };
            await _dbContex.Users.AddAsync(user);
            await _dbContex.SaveChangesAsync();
            var result = await _userRepository.GetUserByUsarNameAndPasswordAsync(email, password);
            Assert.NotNull(result);
        }
    }
}
