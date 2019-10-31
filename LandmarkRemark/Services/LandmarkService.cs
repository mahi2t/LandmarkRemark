using LandmarkRemark.Data;
using LandmarkRemark.Models;
using LandmarkRemark.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace LandmarkRemark.Services
{
    public class LandmarkService : ILandmarkService
    {
        private readonly ApplicationDbContext dbContext;
        private IConfiguration configuration;

        public LandmarkService(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the appsettings json file section.
        /// </summary>
        /// <returns>JsonWebToken</returns>
        public JsonWebToken GetJsonWebTokenSection()
        {
            var jwtSection = new JsonWebToken();
            configuration.GetSection(Constants.AppSettings.JSON_WEB_TOKEN).Bind(jwtSection);
            return jwtSection;
        }

        /// <summary>
        /// private method to verify if note already exists
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <returns></returns>
        public int IsNoteExistsForThisLocation(string email, double longitude, double latitude)
        {
            var response = dbContext.Notes.ToList()
                .FirstOrDefault(x => x.Email?.ToLower() == email.ToLower() &&
                x.Longitude.Equals(longitude) &&
                x.Latitude.Equals(latitude));
            return response != null ? response.Id : 0;
        }
    }
}
