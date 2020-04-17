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
        private Timer buildTimer;
        #endregion

        #region Properties
        /// <summary>
        /// If this factory is being built
        /// </summary>
        public bool IsBuilding { get; private set; }
        #endregion

        #region Methods
        [PunRPC]
        private void DestroyObstacle()
        {
            //Destroy the obstacle object and this rigidbody since we do not move anymore
            Destroy(this.obstacle.gameObject);
            this.obstacle = null;
            Destroy(GetComponent<Rigidbody>());
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Setup
            Material[] materials = this.flagRenderer.materials;
            materials[1] = this.IsControllable() ? GameLogic.Instance.PlayerMaterial : GameLogic.Instance.OpponentMaterial;
            this.flagRenderer.materials = materials;
            this.IsBuilding = this.IsControllable();

            if (this.IsBuilding)
            {
                //Start building
                this.buildTimer = Timer.StartNew();
                Vector3 position = this.transform.localPosition;
                position.y = this.buildHeight;
                this.transform.localPosition = position;
            }
        }

        private void Update()
        {
            if (this.IsBuilding)
            {
                //Move up while building
                float seconds = this.buildTimer.ElapsedSeconds;
                if (seconds < this.Info.BuildTime)
                {
                    Vector3 position = this.transform.localPosition;
                    position.y = Mathf.Lerp(this.buildHeight, 0f, seconds / this.Info.BuildTime);
                    this.transform.localPosition = position;
                }
                else
                {
                    //Set to zero and stop
                    Vector3 position = this.transform.localPosition;
                    position.y = 0f;
                    this.transform.localPosition = position;
                    this.IsBuilding = false;
                    this.buildTimer = null;

                    //Terminate building process
                    this.photonView.RPC(nameof(DestroyObstacle), RpcTarget.All);
                    GameEvents.OnCandyMaxChanged.Invoke(this.candyGiven);
                }
            }
        }

        private void OnDestroy()
        {
            //When destroyed, remove the candy given if done building
            if (this.IsControllable() && !this.IsBuilding)
            {
                GameEvents.OnCandyMaxChanged.Invoke(-this.candyGiven);
            }
        }
        #endregion
    }
}
