using LandmarkRemark.Models;

namespace LandmarkRemark.Services
{
    public interface ILandmarkService
    {
        int IsNoteExistsForThisLocation(string email, double longitude, double latitude);
        JsonWebToken GetJsonWebTokenSection();
    }
}
