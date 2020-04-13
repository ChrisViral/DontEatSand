using DontEatSand.Base;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Entities
{
    [DisallowMultipleComponent, RequireComponent(typeof(Collider))]
    public abstract class Entity : MonoBehaviourPun, ISelectable
    {
        #region Fields
        [SerializeField]
        private int maxHealth = 200;
        [SerializeField]
        private Renderer selectionIndicator;
        [SerializeField]
        private Color selectedColour = Color.green, enemyColour = Color.red, hoveredColour = Color.blue;
        private Color activeColour;
        #endregion

        #region Properties
        [SerializeField]
        private string entityName = string.Empty;
        /// <summary>
        /// Name of the entity
        /// </summary>
        public string EntityName => this.entityName;

        private UnitInfo? info;
        /// <summary>
        /// The UnitInfo associated to this entity
        /// </summary>
        public UnitInfo Info => this.info ?? (this.info = UnitDatabase.GetInfo(this.EntityName)).Value;

        /// <summary>
        /// The Rigidbody associated to this entity
        /// </summary>
        public Rigidbody Rigidbody { get; private set; }

        /// <summary>
        /// The position of this entity
        /// </summary>
        public Vector3 Position => this.Rigidbody.position;

        /// <summary>
        /// The rotation of this entity
        /// </summary>
        public Quaternion Rotation => this.Rigidbody.rotation;

        /// <summary>
        /// The current health of this entity
        /// </summary>
        public int Health { get; protected set; }

        private bool isSelected;
        /// <summary>
        /// If this Entity is currently selected or not
        /// </summary>
        public bool IsSelected
        {
            get => this.isSelected;
            set
            {
                //On value change
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    if (this.isSelected)
                    {
                        //If selected, activate and colour
                        this.selectionIndicator.gameObject.SetActive(true);
                        this.selectionIndicator.material.color = this.activeColour;
                    }
                    else
                    {
                        if (this.isHovered)
                        {
                            //If not active but hovered, set as hovered colour
                            this.selectionIndicator.material.color = this.hoveredColour;
                        }
                        else
                        {
                            //If not hovered, turn off
                            this.selectionIndicator.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        private bool isHovered;
        /// <summary>
        /// If this Entity is currently being hovered or not
        /// </summary>
        public bool IsHovered
        {
            get => this.isHovered;
            set
            {
                //On value change
                if (this.isHovered != value)
                {
                    this.isHovered = value;
                    //Only update if not selected
                    if (!this.IsSelected)
                    {
                        if (this.isHovered)
                        {
                            //If hovered, turn on and colour
                            this.selectionIndicator.gameObject.SetActive(true);
                            this.selectionIndicator.material.color = this.hoveredColour;
                        }
                        else
                        {
                            //Else turn off
                            this.selectionIndicator.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Causes damage to the entity
        /// NOTE: negative damage can be used to heal
        /// </summary>
        /// <param name="amount">Damage to cause</param>
        /// <returns>The damage actually caused</returns>
        public int Damage(int amount)
        {
            int prev = this.Health;
            this.Health = Mathf.Clamp(this.Health - amount, 0, this.maxHealth);
            if (PhotonNetwork.IsConnected)
            {
                //Make sure to broadcast if networked
                this.photonView.RPC(nameof(ReceiveDamage), RpcTarget.Others, amount);
            }
            if (this.Health == 0)
            {
                PhotonUtils.Destroy(this);
            }
            return prev - this.Health;
        }

        /// <summary>
        /// Received a certain amount of damage from the network
        /// </summary>
        /// <param name="amount">Amount of damage to receive</param>
        [PunRPC]
        private void ReceiveDamage(int amount) => this.Health = Mathf.Clamp(this.Health - amount, 0, this.maxHealth);

        /// <summary>
        /// Awake function, use this instead of Awake() to avoid overriding default behaviour
        /// </summary>
        protected virtual void OnAwake() { }
        #endregion

        #region Functions
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
            this.Health = this.maxHealth;

            //Setup selection indicator
            this.activeColour = this.IsControllable() ? this.selectedColour : this.enemyColour;
            this.selectionIndicator.material.color = this.activeColour;
            this.selectionIndicator.gameObject.SetActive(false);

            //If controllable, destroy the discoverable component
            if (this.IsControllable())
            {
                Destroy(GetComponent<Discoverable>());
            }
            OnAwake();
        }
        #endregion
    }
}
