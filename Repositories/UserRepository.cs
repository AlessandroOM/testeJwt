using System.Collections.Generic;
using System.Linq;
using testeJwt.Models;

namespace testeJwt.Repositories
{
    public class UserRepository
    {
        private List<User> Users;

        public UserRepository()
        {
            Users = new List<User>();

            Users.Add(
                new User {Id = 1, Name = "Pedro", Password = "123456", Role = "Gerente"}
            );

            Users.Add(
                new User {Id = 1, Name = "Maria", Password = "123456", Role = "Supervisora"}
            );
        }

        public User Get(string username, string password)
        {
              return Users.Where(x => x.Name.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault<User>();
        }
    }
}