using LandmarkRemark.Models;
using LandmarkRemark.Repository;
using LandmarkRemark.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LandmarkRemark.Controllers
{
    /// <summary>
    /// Note api controller
    /// </summary>
    [ApiController]
    [Route(Constants.ApiRoutes.BASE), Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        /// <summary>
        /// Get method to fetch all the notes
        /// </summary>
        /// <returns>IEnumerable<NoteResponse></returns>
        [HttpGet("all")]
        public IEnumerable<NoteResponse> GetAllNotes()
        {
            var response = noteRepository.GetAllNotes();
            return response;
        }

        /// <summary>
        /// Get method to fetch the search results.
        /// </summary>
        /// <param name="searchText">SearchText</param>
        /// <returns>IEnumerable<NoteResponse></returns>
        [HttpGet("search")]
        public IEnumerable<NoteResponse> GetSearchResults([FromQuery(Name = "text")] string searchText)
        {
            var response = noteRepository.GetSearchResults(searchText);
            return response;
        }

        /// <summary>
        /// Post method to save the note.
        /// </summary>
        /// <param name="note">Note</param>
        /// <returns>IActionResult</returns>
        [HttpPost("add")]
        public IActionResult AddNote(Note note)
        {
            var response = noteRepository.AddNote(note);
            return Ok(response);
        }
    }
}
