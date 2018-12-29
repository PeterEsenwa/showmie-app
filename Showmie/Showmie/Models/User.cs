using System;
using System.Collections.Generic;
using System.Security;

namespace Showmie.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Followers { get; set; }
        public string ProfilePicture { get; set; }
        public string ProfileCover { get; set; }
        public int IntFollowers { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
        //public bool PreserveSignin { get; set; }
        //public List<Notification> Notifications { get; set; }

        public enum UserTypes
        {
            Null = 0,
            Enthusiast = 1,
            Professional = 2
        }

        public User()
        {

        }
    }
}
