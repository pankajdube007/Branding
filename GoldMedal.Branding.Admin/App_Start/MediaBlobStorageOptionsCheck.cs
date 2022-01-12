using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldMedal.Branding.Admin
{
    public static class MediaBlobStorageOptionsCheck
    {
        public static bool CheckOptions(string connectionString, string containerName)
        {
            var optionsAreValid = true;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                optionsAreValid = false;
            }

            if (string.IsNullOrWhiteSpace(containerName))
            {
                optionsAreValid = false;
            }

            return optionsAreValid;
        }
    }
}