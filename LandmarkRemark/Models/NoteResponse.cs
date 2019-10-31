using System;

namespace LandmarkRemark.Models
{
    /// <summary>
    /// Note respone model
    /// </summary>
    public class NoteResponse
    {
        /// <summary>
        /// Note id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User entered remark.
        /// </summary>
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
        /// User full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }
    }
}
