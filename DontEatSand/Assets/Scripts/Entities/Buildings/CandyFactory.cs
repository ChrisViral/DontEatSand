using UnityEngine;

namespace DontEatSand.Entities.Buildings
{
    public class CandyFactory : Entity
    {
        #region Fields
        [SerializeField]
        private int candyGiven = 20;
        #endregion

        #region Methods
        /// <summary>
        /// When the player is set
        /// </summary>
        protected override void PlayerSet()
        {
            //If the player set isn't null, add to it's max candy available
            if (this.Player != null)
            {
                GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
            }
        }
        #endregion

        #region Functions
        private void OnDestroy()
        {
            //When destroyed, remove the candy given
            if (this.Player != null)
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }
        #endregion
    }
}
