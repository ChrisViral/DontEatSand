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
        public void FinishedBuilding()
        {
            //If local player, make sure to update the candy
            if (this.photonView.IsMine)
            {
                GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
            }
        }
        #endregion

        #region Functions
        private void OnDestroy()
        {
            //When destroyed, remove the candy given
            if (this.photonView.IsMine)
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }
        #endregion
    }
}
