using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User App
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Current User
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Is New User
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create User Controller
        /// </summary>
        /// <param name="userName">User</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Empty User Name");
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string gender, DateTime birthDate, double weight = 1, double height = 1)
        {
           CurrentUser.Gender = new Gender(gender);
           CurrentUser.BirthDate = birthDate;
           CurrentUser.Weight = weight;
           CurrentUser.Height = height;
           Save();
        }

        /// <summary>
        /// Save User Data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        /// <summary>
        /// Load User Data
        /// </summary>
        /// <returns>User App</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }

        }

    }
}
