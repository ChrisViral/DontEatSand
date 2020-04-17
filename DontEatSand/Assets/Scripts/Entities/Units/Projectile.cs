using System;
using DontEatSand.Base;
using DontEatSand.Extensions;
using DontEatSand.Utils;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DontEatSand.Entities.Units
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Renderer))]
    public class Projectile : MonoBehaviourPun
    {
        #region Fields
        [SerializeField]
        private float speed = 10f;
        [SerializeField]
        private AnimationCurve arcCurve;
        [SerializeField]
        private int damage = 10;
        [SerializeField]
        private SoundAutoDestroy projectileSound;
        private readonly Timer timer = new Timer();
        private Vector3 startPosition;
        private new Rigidbody rigidbody;
        #endregion

        #region Properties
        private Entity target;
        /// <summary>
        /// Target of this projectile
        /// </summary>
        public Entity Target
        {
            get => this.target;
            set
            {
                if (value && value != this.target)
                {
                    this.target = value;
                    this.timer.Start();
                }
            }
        }
        #endregion

        #region Functions
        private void Awake()
        {
            //Only get components if controllable
            if (this.IsControllable())
            {
                //Setup start data
                this.rigidbody = GetComponent<Rigidbody>();
                this.rigidbody.angularVelocity = Random.insideUnitSphere;
                this.startPosition = this.transform.position;

                //Setup color
                if (PhotonNetwork.IsConnected)
                {
                    GetComponent<Renderer>().material = GameLogic.Instance.PlayerMaterial;
                }
            }
            else
            {
                GetComponent<Renderer>().material = GameLogic.Instance.OpponentMaterial;
            }
        }

        private void Start()
        {
            //If not controllable, just destroy the component
            if (!this.IsControllable())
            {
                Destroy(this);
            }
        }

        private void FixedUpdate()
        {
            //Random rotation
            this.rigidbody.MoveRotation(this.rigidbody.rotation * Quaternion.Euler(this.rigidbody.angularVelocity * Time.fixedDeltaTime));

            if (this.Target)
            {
                //Movement
                Vector3 targetPosition = this.Target.transform.TransformPoint(0f, 1.5f, 0f);
                float startDistance = Vector3.Distance(this.startPosition, targetPosition);
                float completion = Mathf.Clamp01((this.timer.ElapsedSeconds * this.speed) / startDistance);
                float arcHeight =  this.arcCurve.Evaluate(completion) * Mathf.Clamp(Vector3.Distance(this.transform.position, targetPosition), 0.5f, 2f);
                Vector3 position = Vector3.Lerp(this.startPosition, targetPosition, completion) + (Vector3.up * arcHeight);
                this.rigidbody.MovePosition(position);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Only collide with the non-trigger collider of the target
            if (!other.isTrigger && this.Target && other.transform.parent == this.Target.transform)
            {
                //Collide with target
                this.target.Damage(this.damage);
                PhotonUtils.Destroy(this);
                if (this.projectileSound) { PhotonUtils.Instantiate(this.projectileSound, this.transform.position); }

                //Make sure we mark the unit as under attack
                if (this.target is Unit unit)
                {
                    unit.IsUnderAttackFlag = true;
                }
            }
        }
        #endregion
    }
}
