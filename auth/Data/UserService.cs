using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Auth01.Models;

namespace Auth01.Data
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
            new User(){Id=99, Name="Hans", Role = "user", Email="t@t.de", Password="9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08"}
        };

        public User GetUserByMail(string email)
        {
            return _users.SingleOrDefault(u => Equals(u.Email, email));
        }

        public User Login(string user, string password)
        {
            var stringBuilder = new StringBuilder();
            var hash = string.Empty;
            using (var sh = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                var bytes = sh.ComputeHash(enc.GetBytes(password));

                foreach (byte b in bytes)
                    stringBuilder.Append(b.ToString("x2"));

                hash = stringBuilder.ToString();
            }
            return _users.SingleOrDefault(u => Equals(u.Name, user) && Equals(u.Password, hash));
        }


        int counter = 1;
        public bool Register(string name, string password, string role, string email)
        {
            if (_users.Any(u => Equals(u.Name, name)))
            {
                return false;
            }
            var stringBuilder = new StringBuilder();
            var hash = string.Empty;
            using (var sh = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                var bytes = sh.ComputeHash(enc.GetBytes(password));

                foreach (byte b in bytes)
                    stringBuilder.Append(b.ToString("x2"));

                hash = stringBuilder.ToString();
            }

            _users.Add(new User()
            {
                Id = counter++,
                Name = name,
                Password = hash,
                Role = role,
                Email = email
            });
            return true;
        }
    }
}