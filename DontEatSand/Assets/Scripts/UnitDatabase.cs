using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DontEatSand.Utils;
using Newtonsoft.Json;

namespace DontEatSand
{
    /// <summary>
    /// UnitInfo Database
    /// </summary>
    public static class UnitDatabase
    {
        #region Properties
        /// <summary>
        /// The amount of units stored in the UnitDatabase
        /// </summary>
        public static int Count { get; }

        /// <summary>
        /// UnitInfo database, keyed by name
        /// </summary>
        public static ReadOnlyDictionary<string, UnitInfo> Database { get; }
        #endregion

        #region Static methods
        /// <summary>
        /// Gets the UnitInfo for this unit name
        /// </summary>
        /// <param name="name">Name of the Unit to get</param>
        /// <returns>The UnitInfo associated to this name</returns>
        public static UnitInfo GetInfo(string name) => Database[name];

        /// <summary>
        /// Checks if the Database contains the specified unit
        /// </summary>
        /// <param name="name">Name of the unit to find</param>
        /// <returns>True if the unit exists in the database, false otherwise</returns>
        public static bool ContainsUnit(string name) => Database.ContainsKey(name);

        /// <summary>
        /// Tries to get the UnitInfo of the specified name and stores it in the out parameter
        /// </summary>
        /// <param name="name">Name of the info to try to find</param>
        /// <param name="info">Variable to store the found info in</param>
        /// <returns>True if the info was found, false otherwise</returns>
        public static bool TryGetInfo(string name, out UnitInfo info) => Database.TryGetValue(name, out info);
        #endregion

        #region Constructors
        /// <summary>
        /// Sets up the database for first use
        /// </summary>
        static UnitDatabase()
        {
            //Load the Json
            string text = File.ReadAllText(DESUtils.DatabaseLocation);
            UnitInfo[] info = JsonConvert.DeserializeObject<UnitInfo[]>(text);
            //Setup the database
            Database = new ReadOnlyDictionary<string, UnitInfo>(info.ToDictionary(u => u.Name, u => u));
            Count = Database.Count;
        }
        #endregion
    }
}
