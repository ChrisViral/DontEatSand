using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace DontEatSand.Entities.Buildings
{
    public class Castle : Entity
    {
        #region Fields
        [SerializeField]
        private Transform spawnLocation, spawnParent;
        #endregion

        #region Properties
        [SerializeField, Tooltip("All the entities that can be created by this castle")]
        private Entity[] units;
        /// <summary>
        /// A list of all the units that can be created by this Castle
        /// </summary>
        public ReadOnlyCollection<Entity> Units { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the Entity at the given index in the castle's entity list
        /// </summary>
        /// <param name="index">Index of the unit to create in the entity list</param>
        /// <exception cref="ArgumentOutOfRangeException">If the index is out of range of the entity list</exception>
        public void CreateEntity(int index)
        {
            if (index < 0 && index >= this.units.Length) throw new ArgumentOutOfRangeException(nameof(index), index, "Index must be within the range of the entity list");

            //Get unit info
            Entity unit = this.units[index];
            UnitInfo info = UnitDatabase.GetInfo(unit.EntityName);

            //Check if we have the resources to create it
            if (GameLogic.Player.CheckResourcesAvailable(info.SandCost, info.CandyCost))
            {
                //Request resources
                if (info.SandCost > 0)
                {
                    GameEvents.OnSandChanged.Invoke(info.SandCost);
                }
                if (info.CandyCost > 0)
                {
                    GameEvents.OnCandyChanged.Invoke(info.CandyCost);
                }
                //Spawn entity
                Entity spawned = Instantiate(unit, this.spawnLocation.position, unit.Rotation, this.spawnParent);
                spawned.Player = GameLogic.Player;
            }
        }
        #endregion

        #region Functions
        protected override void OnAwake() => this.Units = Array.AsReadOnly(this.units);
        #endregion
    }
}
