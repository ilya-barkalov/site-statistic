using System;
using System.ComponentModel.DataAnnotations;

namespace SiteStatistic.Core.Data.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string FirstName { get; protected set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string LastName { get; protected set; }

        /// <summary>
        /// Middle name
        /// </summary>
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string MiddleName { get; protected set; }
        
        /// <summary>
        /// Full name 
        /// <para>
        ///     Builds by pattern: <see cref="LastName"/> + <see cref="FirstName"/> + <see cref="MiddleName"/>
        /// </para>
        /// </summary>
        public string FullName => $"{LastName} {FirstName} {MiddleName}";

        [Obsolete("Constructor using only by ef core", true)]
        protected User() { }

        public User(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;

            Validator.ValidateObject(this, new ValidationContext(this));
        }
    }
}
