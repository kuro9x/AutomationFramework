using ProjectCore.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.Unsplash.Services.Constants
{
    internal class APIConstant
    {
        public static string GetAPIUrl()
        {
            return Application.GetConfig()["application:apiBaseUrl"];
        }

        //public static string DOMAIN = "https://unsplash.com/";

        public static string GetCollectionEndPoint = GetAPIUrl()+"collection";


    }
}
