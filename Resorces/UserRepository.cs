using Entities;
using Repositories;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository: IRepository
    {
        private static string pathFile = "C:/Users/325739092/source/repos/WebSite/Resorces/user.txt";

        public User addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(pathFile).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(pathFile, userJson + Environment.NewLine);
            return user;
        }

        public async Task<User> GetUserByUsarNameAndPassword(string userName, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile =await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == userName && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public async Task<User> update(int id, User userUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(pathFile);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userUpdate));
                System.IO.File.WriteAllText(pathFile, text);
                return userUpdate;
            }
            return null;
        }

        public async Task<User> getUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;

        }

    } 
}