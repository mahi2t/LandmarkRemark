using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemark.Utils
{
    public static class Constants
    {
        public static class ApiRoutes
        {
            public const string BASE = "api/[controller]";
        
        }

        public static class AppSettings {
            public const string DEFAULT_CONNECTION = "DefaultConnection";
            public const string JSON_WEB_TOKEN = "JsonWebToken";           
        }

        public static class General {
            public const string POLICY_NAME = "LandmarkPolicy";
        }
    }
}
