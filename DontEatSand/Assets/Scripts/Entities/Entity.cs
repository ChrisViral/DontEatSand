using UnityEngine;

namespace DontEatSand.Entities
{
    [DisallowMultipleComponent, RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class Entity : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private int maxHealth = 200;
        #endregion

        #region Properties
        [SerializeField]
        private string entityName = string.Empty;
        /// <summary>
        /// Name of the entity
        /// </summary>
        public string EntityName => this.entityName;

        private Player player;
        /// <summary>
        /// The Player owning this entity
        /// </summary>
        public Player Player
        {
            get => this.player;
            set
            {
                this.player = value;
                PlayerSet();
            }
        }

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
            if (this.Health == 0)
            {
                Destroy(this);
            }
            return prev - this.Health;
        }

        /// <summary>
        /// Awake function, use this instead of Awake() to avoid overriding default behaviour
        /// </summary>
        protected virtual void OnAwake() { }

        /// <summary>
        /// Called when the player owning this entity is set
        /// </summary>
        protected virtual void PlayerSet() { }
        #endregion

        #region Functions
        private void Awake()
        {
            this.Rigidbody = GetComponent<Rigidbody>();
            this.Health = this.maxHealth;
            OnAwake();
        }
        #endregion
    }
}
