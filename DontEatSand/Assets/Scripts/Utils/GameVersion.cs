using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// Static class holding the game's Version info
    /// </summary>
    public static class GameVersion
    {
        #region Constants
        /// <summary>
        /// Name of the BuildID file
        /// </summary>
        private const string extension  = ".build";
        /// <summary>
        /// Format of the saved date time
        /// </summary>
        private const string timeFormat = "dd/MM/yyyy-HH:mm:ss";
        /// <summary>
        /// The regex pattern to parse the build file
        /// </summary>
        private const string pattern    = @"v(\d+\.\d+\.\d+\.\d+)\|([\w-]+)@(\d{2}/\d{2}/\d{4}-\d{2}:\d{2}:\d{2})UTC";
        #endregion

        #region Static properties
        /// <summary>
        /// Major version number
        /// </summary>
        public static int Major => Version.Major;
        /// <summary>
        /// Minor version number
        /// </summary>
        public static int Minor => Version.Minor;
        /// <summary>
        /// Build version number
        /// </summary>
        public static int Build => Version.Build;
        /// <summary>
        /// Revision version number
        /// </summary>
        public static int Revision => Version.Revision;
        /// <summary>
        /// Full version string
        /// </summary>
        public static string VersionString { get; }
        /// <summary>
        /// Current game version
        /// </summary>
        public static Version Version { get; }
        /// <summary>
        /// The author of the build
        /// </summary>
        public static string Author { get; }
        /// <summary>
        /// UTC time of the Build
        /// </summary>
        public static DateTime BuildTime { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Loads the current game version from the BuildID file
        /// </summary>
        static GameVersion()
        {
            //Get file path
#if UNITY_EDITOR
            string path = Path.Combine(Directory.GetParent(Application.dataPath).FullName, Application.productName.ToLowerInvariant() + extension);
#else
            string path = Path.Combine(Application.dataPath, Application.productName.ToLowerInvariant() + extension);
#endif

            //Check if file exists
            if (!File.Exists(path)) { throw new FileNotFoundException("Game version file could not be found", path); }
            try
            {
                //Read version info from file
                string[] data = Regex.Match(File.ReadAllText(path, Encoding.ASCII).Trim(), pattern)
                                     .Groups.Cast<Group>()
                                     .Skip(1)
                                     .Select(g => g.Captures[0].Value)
                                     .ToArray();

                //Parse version info
                VersionString = data[0];
                Version = new Version(VersionString);
                Author = data[1];
                BuildTime = DateTime.SpecifyKind(DateTime.ParseExact(data[2], timeFormat, CultureInfo.InvariantCulture), DateTimeKind.Utc);
            }
            catch (Exception e)
            {
                //Make sure nothing is null
                VersionString = string.Empty;
                Version = new Version(0, 0, 0, 0);
                Author = string.Empty;

                //Throw if something goes wrong
                throw new FileLoadException("Game version file could not be read properly", path, e);
            }
        }
        #endregion
    }
}