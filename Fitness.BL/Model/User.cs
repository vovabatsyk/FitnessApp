using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Methods

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }

        #endregion

            /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="birthDate">BirthDate</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region CheckingConditions

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Empty Name");
            }

            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender), "Gender don't be a null");
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Wrong Birthdate", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Wrong Weight", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Wrong Height", nameof(height));
            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString() => $"Name: {Name}, gender: {Gender.Name}, birthdate: {BirthDate}, weight: {Weight}, height: {Height}\n";
    }
}
