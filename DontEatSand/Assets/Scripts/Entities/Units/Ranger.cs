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
                // Acknowledge clicked entity as a target for this unit
                if (target is Entity entity) //&& !entity.IsControllable())
                {
                    this.Target = entity;
                }
                else // clicked on the ground somewhere
                {
                    this.Target = null;
                }
            }
        }

        public override void Attack(Entity target)
        {
            base.Attack(target);
            PhotonUtils.Instantiate(this.projectile, this.transform.TransformPoint(this.launchLocation)).Target = target;
        }
        #endregion

        #region Properties
        public override bool CanAttack 
        {
            get
            {
                bool attackReady = false;
                if(Time.time > this.attackStart + this.attackInterval)
                {
                    this.attackStart = Time.time;
                    attackReady = true;
                }
                return attackReady && this.Target != null && Vector3.Distance(this.Position, this.Target.Position) < 10.0f;
            }
        }
        #endregion

        #region Functions
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            if(this.IsSelected)
            {
                HasOrderFlag = true;
                // Acknowledge clicked entity as a target for this unit
                if (target is Entity entity) //&& !entity.IsControllable())
                {
                    this.Target = entity;
                }
            }
        }

        public override void Attack(Entity target)
        {
            base.Attack(target);
                
            target.Damage(10);

            if(target is Unit unit) // attacking a unit
            {
                unit.IsUnderAttackFlag = true;
            }
            else // attacking a building
            {

            }
            
        }

        protected override void OnUpdate()
        {
            // if target exists and is within range
            if(CanAttack && Target != null)
            {
                Attack(Target);
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();

            // Set throwing animation trigger
            this.attackTriggerName = Animator.StringToHash("Throwing");
        }

        protected override void OnUpdate()
        {
            if(this.CanAttack)
            {
                Attack(this.Target);
            }
        }
        #endregion
    }
}
