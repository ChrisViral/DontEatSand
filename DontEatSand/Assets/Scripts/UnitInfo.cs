using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace DontEatSand
{
    /// <summary>
    /// Unit Types
    /// </summary>
    public enum UnitType
    {
        WORKER,
        COMBAT,
        RANGED,
        SUPPORT,
        BUILDING
    }

    /// <summary>
    /// UnitInfo struct
    /// </summary>
    public readonly struct UnitInfo
    {
        #region Properties
        /// <summary>
        /// Name of the Unit
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of the Unit
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Type of Unit
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public UnitType Type { get; }

        /// <summary>
        /// Sand cost of the unit
        /// </summary>
        public int SandCost { get; }

        /// <summary>
        /// Candy cost of the unit
        /// </summary>
        public int CandyCost { get; }

        /// <summary>
        /// The time required to build this unit
        /// </summary>
        public float BuildTime { get; }

        /// <summary>
        /// This unit's icon
        /// </summary>
        public Sprite Icon { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new UnitInfo with the specified parameters
        /// </summary>
        /// <param name="name">Name of the Unit</param>
        /// <param name="description">Description of the Unit</param>
        /// <param name="type">Type of Unit</param>
        /// <param name="sandCost">Sand cost of the Unit</param>
        /// <param name="candyCost">Candy cost of the Unit</param>
        /// <param name="buildTime">The build time of the Unit</param>
        /// <param name="icon">Name of the UI icon for this unit</param>
        [JsonConstructor]
        public UnitInfo(string name, string description, UnitType type, int sandCost, int candyCost, float buildTime, string icon)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.SandCost = sandCost;
            this.CandyCost = candyCost;
            this.BuildTime = buildTime;
            this.Icon = string.IsNullOrEmpty(icon) ? null : Resources.Load<Sprite>(icon);
        }
        #endregion
    }
}
