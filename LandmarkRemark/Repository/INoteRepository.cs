using LandmarkRemark.Models;
using System.Collections.Generic;

namespace LandmarkRemark.Repository
{
    /// <summary>
    /// Note Repository
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// Add Note
        /// </summary>
        /// <param name="note">Note</param>
        /// <returns>IEnumerable<NoteResponse></returns>
        IEnumerable<NoteResponse> AddNote(Note note);

        /// <summary>
        /// Gets all the notes saved in database.
        /// </summary>
        /// <returns>IEnumerable<NoteResponse></returns>
        IEnumerable<NoteResponse> GetAllNotes();

        /// <summary>
        /// Gets the search results based on input.
        /// </summary>
        /// <param name="searchText">SearchText</param>
        /// <returns>IEnumerable<NoteResponse></returns>
        IEnumerable<NoteResponse> GetSearchResults(string searchText);
    }
}
