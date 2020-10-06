using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create New Gender
        /// </summary>
        /// <param name="name">Gender Name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Gender don't be a null");
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
