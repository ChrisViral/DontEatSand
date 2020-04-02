using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DontEatSand.Base;
using DontEatSand.Utils;
using Newtonsoft.Json;

namespace DontEatSand
{
    public class UnitDatabase : Singleton<UnitDatabase>
    {
        #region Properties
        /// <summary>
        /// UnitInfo database, keyed by name
        /// </summary>
        public ReadOnlyDictionary<string, UnitInfo> Database { get; private set; }

        /// <summary>
        /// If the unit database is loaded or not
        /// </summary>
        public bool Loaded { get; private set; }
        #endregion

        #region Static methods
        /// <summary>
        /// Gets the UnitInfo for this unit name
        /// </summary>
        /// <param name="name">Name of the Unit to get</param>
        /// <returns>The UnitInfo associated to this name</returns>
        public static UnitInfo GetInfo(string name) => Instance.Database[name];
        #endregion

        #region Functions
        private void Start()
        {
            //Load the Json
            string text = File.ReadAllText(DESUtils.DatabaseLocation);
            List<UnitInfo> info = JsonConvert.DeserializeObject<List<UnitInfo>>(text);
            this.Database = new ReadOnlyDictionary<string, UnitInfo>(info.ToDictionary(u => u.Name, u => u));

            //Fire the completion event
            this.Loaded = true;
            GameEvents.OnUnitDatabaseLoaded.Invoke();
        }
        #endregion
    }
}
