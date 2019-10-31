using System;
using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.Models
{
    /// <summary>
    /// Remarks data table.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Primary key for Remark data table
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User entered remark value.
        /// </summary>
        [Required]
        public string Remark { get; set; }

        /// <summary>
        /// Latitude value.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude value.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// DateTime of when the note is added.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>       
        public string Email { get; set; }
    }
}
