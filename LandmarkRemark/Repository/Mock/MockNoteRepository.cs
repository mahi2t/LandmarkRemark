using LandmarkRemark.Models;
using System.Collections.Generic;
using System.Linq;

namespace LandmarkRemark.Repository.Mock
{
    /// <summary>
    /// NoteRepository Mock
    /// </summary>
    public class MockNoteRepository : INoteRepository
    {
        private readonly List<NoteResponse> notes;
        private readonly List<ApplicationUser> users;

        public MockNoteRepository()
        {
            notes = new List<NoteResponse>() {
                new NoteResponse {Id=1,   Remark = "this is first Note" , Latitude =523.987, Longitude = 908.786 },
                 new NoteResponse { Id=2,  Remark = "second one", Latitude = 423.987, Longitude = 808.786 },
                  new NoteResponse { Id=3, Remark = "this is third Note", Latitude = 323.987, Longitude = 708.786 },
                new NoteResponse { Id=4, Remark = "last Note", Latitude = 223.987, Longitude = 608.786 }
            };

            users = new List<ApplicationUser> {
                new ApplicationUser{Email="x.y@z.com", Id=1, FirstName="x", LastName="y" }
            };
        }
        public IEnumerable<NoteResponse> AddNote(Note note)
        {
            var user = users.FirstOrDefault(x => x.Email == note.Email);
            note.Id = notes.Max(x => x.Id) + 1;
            var response = new NoteResponse
            {
                Latitude = note.Latitude,
                Longitude = note.Longitude,
                Email = user.Email,
                FullName = $"{user.FirstName}, {user.LastName}"
            };
            notes.Add(response);
            return notes;
        }

        public IEnumerable<NoteResponse> GetAllNotes()
        {
            return notes;
        }

        public IEnumerable<NoteResponse> GetSearchResults(string searchText)
        {
            return notes.Where(x => x.Remark.Contains(searchText));
        }
    }
}
