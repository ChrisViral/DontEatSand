using DontEatSand.Utils;
using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Ranger : Unit
    {
        #region Fields
        [SerializeField]
        private Vector3 launchLocation;
        [SerializeField]
        private Projectile projectile;
        #endregion

        #region Methods
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            //FROM CHRIS:
            //Just testing out the projectile, I don't know if this is actually good for BehaviourTree implementation
            base.ProcessCommand(destination, target);

            if(this.IsSelected)
            {
                this.HasOrderFlag = true;
                // Acknowledge clicked entity as a target for this unit
                if (target is Entity entity) //&& !entity.IsControllable())
                {
                    this.Target = entity;
                }
            }
        }

        public override void Attack(Entity target)
        {
            if(target != this)
            {
                base.Attack(target);
                PhotonUtils.Instantiate(this.projectile, this.transform.TransformPoint(this.launchLocation)).Target = target;
            }

        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            base.OnAwake();

            this.Agent.stoppingDistance = 0.5f;
            // Set throwing animation trigger
            this.attackTriggerName = Animator.StringToHash("Throwing");
        }

        protected override void OnUpdate()
        {
            if(this.CanAttack && this.Target)
            {
                this.Agent.stoppingDistance = this.attackRange * 0.6f;
                Attack(this.Target);
            }
            if(!this.Target)
            {
                this.Agent.stoppingDistance = 0.5f;
            }
        }
        #endregion
    }
}
