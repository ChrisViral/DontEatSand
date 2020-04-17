using DontEatSand.Extensions;
using UnityEngine;

namespace DontEatSand.Entities.Buildings
{
    public class CandyFactory : Entity
    {
        #region Fields
        [SerializeField]
        private int candyGiven = 20;
        [SerializeField]
        private Renderer flagRenderer;
        #endregion

        #region Methods
        /// <summary>
        /// When the rtsPlayer is set
        /// </summary>
        public void FinishedBuilding()
        {
            //If local player, make sure to update the candy
            if (this.IsControllable())
            {
                GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
            }
        }
        #endregion

        #region Functions<
        protected override void OnAwake()
        {
            Material[] materials = this.flagRenderer.materials;
            materials[1] = this.IsControllable() ? GameLogic.Instance.PlayerMaterial : GameLogic.Instance.OpponentMaterial;
            this.flagRenderer.materials = materials;
        }

        private void OnDestroy()
        {
            //When destroyed, remove the candy given
            if (this.IsControllable())
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }
        #endregion
    }
}
