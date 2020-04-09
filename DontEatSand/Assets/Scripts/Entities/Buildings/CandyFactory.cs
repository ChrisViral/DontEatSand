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
        /// When the rtsPlayer is set
        /// </summary>
        protected override void PlayerSet()
        {
            //If the rtsPlayer set isn't null, add to it's max candy available
            if (this.RTSPlayer != null)
            {
                GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
            }
        }
        #endregion

        #region Functions
        private void OnDestroy()
        {
            //When destroyed, remove the candy given
            if (this.RTSPlayer != null)
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }
        #endregion
    }
}
