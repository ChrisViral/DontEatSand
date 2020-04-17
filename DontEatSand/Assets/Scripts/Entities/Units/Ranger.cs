using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Ranger : Unit
    {
        #region Fields
        [SerializeField]
        private GameObject projectile;
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

            if(this.Target == null && Vector3.Distance(this.Position, agent.destination) < 0.5f)
            {
                // no target and arrived to player-commanded destination
                HasOrderFlag = false;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            
            // Set throwing animation trigger
            attackTriggerName = Animator.StringToHash("Throwing");
        }
        #endregion
    }
}
