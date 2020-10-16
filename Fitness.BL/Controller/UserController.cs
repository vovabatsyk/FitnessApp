using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController : BaseController
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

        /// <summary>
        /// Set New User Data
        /// </summary>
        /// <param name="gender">User gender</param>
        /// <param name="birthDate">User birthDate</param>
        /// <param name="weight">User weight</param>
        /// <param name="height">User height</param>
        public void SetNewUserData(string gender, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Load User Data
        /// </summary>
        /// <returns>User App</returns>
        private List<User> GetUsersData() => Load<User>() ?? new List<User>();

        /// <summary>
        /// Save User Data
        /// </summary>
        public void Save()
        { 
           Save(Users);
        }

    }
}
