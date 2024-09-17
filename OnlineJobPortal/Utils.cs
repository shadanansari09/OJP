using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineJobPortal
{
    public class Utils
    {
        public static bool isValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtensions = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i <= fileExtensions.Length - 1; i++)
            {
                if (fileName.Contains(fileExtensions[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }


        public static bool isValidResumeExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtensions = { ".doc", ".docx", ".pdf" };
            for (int i = 0; i <= fileExtensions.Length - 1; i++)
            {
                if (fileName.Contains(fileExtensions[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}