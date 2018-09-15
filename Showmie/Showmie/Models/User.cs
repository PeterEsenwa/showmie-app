using System;
using System.Collections.Generic;
using System.Security;

namespace Showmie.Models
{
    internal class User
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public SecureString Password { get; set; }
        public UserTypes Type { get; set; }
        public bool PreserveSignin { get; set; }
        public List<Notification> Notifications { get; set; }

        public enum UserTypes
        {
            Null = 0,
            Enthusiast = 1,
            Professional = 2
        }

        public User(string firstname, string surname, string username, string email, SecureString password, UserTypes type)
        {
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password;
            Type = type;
        }
    }
}
