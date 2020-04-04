using UnityEngine;

namespace DontEatSand
{
    /// <summary>
    /// RTS Player class
    /// </summary>
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        #region Fields
        [SerializeField, Tooltip("The amount of sand the player starts with")]
        private int startingSand = 500;
        [SerializeField, Tooltip("The amount of candy available from the player's main base")]
        private int baseCandy = 30;
        #endregion

        #region Properties
        /// <summary>
        /// Total sand the player has available
        /// </summary>
        public int Sand { get; private set; }

        /// <summary>
        /// Max candy at the player's disposition
        /// </summary>
        public int MaxCandy { get; private set; }

        /// <summary>
        /// Candy used by the player's unit
        /// </summary>
        public int UsedCandy { get; private set; }

        /// <summary>
        /// Available candy for extra unit creation
        /// </summary>
        public int AvailableCandy => this.MaxCandy - this.UsedCandy;
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the specified resources are available
        /// </summary>
        /// <param name="sand">Sand amount to request</param>
        /// <param name="candy">Candy amount to request</param>
        /// <returns>True if the resources are available, false otherwise</returns>
        public bool CheckResourcesAvailable(int sand, int candy) => sand <= this.Sand && candy <= this.AvailableCandy;

        /// <summary>
        /// Change in candy total
        /// </summary>
        /// <param name="amount"></param>
        private void OnCandyMaxChanged(int amount) => this.MaxCandy += amount;

        /// <summary>
        /// Change in sand amount
        /// </summary>
        /// <param name="amount">Amount of sand added or removed</param>
        private void OnSandChanged(int amount) => this.Sand += amount;

        /// <summary>
        /// Change in used candy amount
        /// </summary>
        /// <param name="amount">Candy used or freed</param>
        private void OnCandyChanged(int amount) => this.UsedCandy += amount;
        #endregion

        #region Functions
        private void Awake()
        {
            //Setup
            this.Sand = this.startingSand;
            this.MaxCandy = this.baseCandy;

            //Event registering
            GameEvents.OnCandyMaxChanged.AddListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.AddListener(OnSandChanged);
            GameEvents.OnCandyChanged.AddListener(OnCandyChanged);
        }

        private void OnDestroy()
        {
            //Remove event listeners
            GameEvents.OnCandyMaxChanged.RemoveListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.RemoveListener(OnSandChanged);
            GameEvents.OnCandyChanged.RemoveListener(OnCandyChanged);
        }
        #endregion
    }
}
