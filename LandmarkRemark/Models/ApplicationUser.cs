using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.Models
{
    /// <summary>
    /// User data table
    /// </summary>
    public class ApplicationUser
    {
        /// <summary>
        /// Primary key for User data model
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of user.
        /// </summary>
        [MaxLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of user.
        /// </summary>
        [MaxLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Email of user to login.
        /// </summary>
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        /// <summary>
        /// Password to login.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
