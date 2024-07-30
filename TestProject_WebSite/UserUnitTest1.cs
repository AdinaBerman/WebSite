using Moq;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Entities;
using Repositories;
using Moq.EntityFrameworkCore;


namespace TestProject_WebSite
{
    public class UserUnitTest1
    {
        [Fact]
        public async Task GetUser_Validcredtials_RerurnUser()
        {
            var user = new User { Email = "email@gmail.com", Password = "email" };

            var mockContex = new Mock<PruductsDbContext>();
            var users = new List<User>() { user };
            mockContex.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContex.Object);
            var result = await userRepository.GetUserByUsarNameAndPasswordAsync("email@gmail.com", "email");
            Assert.Equal(user, result);

        }
    }
}