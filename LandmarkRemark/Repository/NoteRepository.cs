using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Repository
{
    /// <summary>
    /// Note Repository
    /// </summary>
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILandmarkService landmarkService;

        public NoteRepository(ApplicationDbContext dbContext,
            ILandmarkService landmarkService)
        {
            this.dbContext = dbContext;
            this.landmarkService = landmarkService;
        }

        /// <summary>
        /// Add Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns>IEnumerable<NoteResponse>Note</returns>
        public IEnumerable<NoteResponse> AddNote(Note note)
        {
            var noteId = landmarkService.IsNoteExistsForThisLocation(note.Email, note.Longitude, note.Latitude);
            note.CreatedDate = DateTime.Now;
            if (noteId > 0)
            {
                dbContext.Notes.Update(note);
            }
            else
            {
                dbContext.Notes.Add(note);
            }

            var response = dbContext.SaveChanges();
            if (response <= 0)
            {
                return null;
            }
            return GetAllNotes();
        }

        /// <summary>
        /// Gets all the notes saved in database.
        /// </summary>
        /// <returns>IEnumerable<NoteResponse></returns>
        public IEnumerable<NoteResponse> GetAllNotes()
        {
            var response = from n in dbContext.Notes
                           join u in dbContext.ApplicationUsers on n.Email equals u.Email
                           orderby n.CreatedDate descending
                           select (new NoteResponse
                           {
                               FullName = $"{u.FirstName}, { u.LastName}",
                               Email = u.Email,
                               Remark = n.Remark,
                               Longitude = n.Longitude,
                               Latitude = n.Latitude,
                               CreatedDate = n.CreatedDate
                           });
            return response;
        }

        /// <summary>
        /// Gets the search results based on input.
        /// </summary>
        /// <param name="searchText">SearchText</param>
        /// <returns>IEnumerable<NoteResponse></returns>
        public IEnumerable<NoteResponse> GetSearchResults(string searchText)
        {
            var response = from n in dbContext.Notes
                           join u in dbContext.ApplicationUsers on n.Email equals u.Email
                           where EF.Functions.Like(n.Remark, $"%{searchText}%")
                           orderby n.CreatedDate descending
                           select (new NoteResponse
                           {
                               FullName = $"{u.FirstName}, { u.LastName}",
                               Email = u.Email,
                               Remark = n.Remark,
                               Longitude = n.Longitude,
                               Latitude = n.Latitude,
                               CreatedDate = n.CreatedDate
                           });
            return response;
        }


    }
}
