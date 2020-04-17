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
        [SerializeField, Header("Sound Effect")]
        protected AudioClip[] soundEffect;
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

        protected override void OnStart()
        {
            // construction sound
            PlaySound(1);
        }

        private void OnDestroy()
        {
            // collapse sound
            PlaySound(0);
            //When destroyed, remove the candy given
            if (this.IsControllable())
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }

        /// <summary>
        /// Play isolated Sound at position at clip index
        /// even if the current object is on destroy
        /// </summary>
        /// <param name="index"></param>
        protected void PlaySound(int index)
        {
            if (soundEffect.Length > index)
            {
                AudioSource.PlayClipAtPoint(soundEffect[index], transform.position);
            }
        }
        #endregion
    }
}
