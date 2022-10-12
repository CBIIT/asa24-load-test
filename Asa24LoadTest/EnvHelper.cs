using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa24LoadTest
{
    public static class EnvHelper
    {
        private static readonly String WestatMobileDemo = "https://asa24mobiledemo.wesdemo.com/";
        private static readonly String AWSDemo = "https://asa24-stage.nih.gov/";

        /// <summary>
        /// The project id for CANDM1 in a demo derived database.
        /// </summary>
        private static readonly String StudyIdDemo = "9c6bf45d-cbb7-4e6c-8d46-6ac987d53b0a";
        /// <summary>
        /// The project id for CANDM1 in a production derived database.
        /// </summary>
        private static readonly String StudyIdProduction = "986e6bc0-c134-49e9-a683-43397fbee8c7";

        public static String GetRootDomain()
        {
            return AWSDemo;
        }

        [Obsolete("The code does not pick this up for some reason")]
        public static String GetStudyId()
        {
            return StudyIdProduction;
        }
    }
}
