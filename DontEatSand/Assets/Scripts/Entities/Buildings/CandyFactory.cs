using DontEatSand.Entities.Units;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using Photon.Pun;
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
        [SerializeField]
        private float buildHeight;
        [SerializeField]
        private GameObject obstacle;
        [SerializeField, Header("Sound Effect")]
        protected AudioClip[] soundEffect;
        private float originalY, undergroundY;
        private Timer buildTimer;
        #endregion

        #region Properties
        /// <summary>
        /// If this factory is being built
        /// </summary>
        public bool IsBuilding { get; private set; }

        /// <summary>
        /// If the factory has been built completely yet
        /// </summary>
        public bool Built { get; private set; }

        /// <summary>
        /// Farmer building this factory
        /// </summary>
        public Farmer Builder { get; set; }
        #endregion

        #region Methods
        public void StartBuilding()
        {
            if (this.IsControllable())
            {
                //Start building
                this.IsBuilding = true;
                this.buildTimer = Timer.StartNew();
                if (PhotonNetwork.IsConnected)
                {
                    this.photonView.RPC(nameof(SetIsBuilding), RpcTarget.Others, true);
                }
            }
            // construction sound
            PlaySound(1);
        }

        private void DoneBuilding()
        {
            //Set to zero and stop
            Vector3 position = this.transform.position;
            position.y = this.originalY;
            this.transform.position = position;

            //Set flags
            this.IsBuilding = false;
            this.Built = true;
            this.buildTimer = null;

            //Terminate building process
            GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
            FinishBuildOnNetwork();
            if (PhotonNetwork.IsConnected)
            {
                this.photonView.RPC(nameof(FinishBuildOnNetwork), RpcTarget.Others);
            }

            //Notify farmer
            this.Builder.DoneBuilding();
            this.Builder = null;

            // construction done sound
            PlaySound(2);
        }

        [PunRPC]
        private void SetIsBuilding(bool value) => this.IsBuilding = value;

        [PunRPC]
        private void FinishBuildOnNetwork()
        {
            //Set flags
            this.IsBuilding = false;
            this.Built = true;

            //Destroy the obstacle object
            Destroy(this.obstacle.gameObject);
            this.obstacle = null;
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Setup
            Material[] materials = this.flagRenderer.materials;
            materials[1] = this.IsControllable() ? GameLogic.Instance.PlayerMaterial : GameLogic.Instance.OpponentMaterial;
            this.flagRenderer.materials = materials;

            if (this.IsControllable())
            {
                //Start building
                Vector3 position = this.transform.position;
                this.originalY = position.y;
                this.undergroundY = this.originalY - this.buildHeight;
                position.y = this.undergroundY;
                this.transform.position = position;
            }
        }

        private void Update()
        {
            if (this.IsBuilding && this.IsControllable())
            {
                //Move up while building
                float seconds = this.buildTimer.ElapsedSeconds;
                if (seconds < this.Info.BuildTime)
                {
                    Vector3 position = this.transform.position;
                    position.y = Mathf.Lerp(this.undergroundY, this.originalY, seconds / this.Info.BuildTime);
                    this.transform.position = position;
                }
                else { DoneBuilding(); }
            }
        }

        private void OnDestroy()
        {
            // collapse sound
            PlaySound(0);
            //When destroyed, remove the candy given if done building
            if (this.IsControllable() && !this.Built)
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
