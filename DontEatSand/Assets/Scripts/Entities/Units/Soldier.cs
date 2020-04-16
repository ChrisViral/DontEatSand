using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    public class Soldier : Unit
    {
        private float attackStart = 0f;
        private float attackInterval = 1.0f;
        
        private bool canAttack {
            get
            {
                bool attackReady = false;
                if(Time.time > attackStart + attackInterval)
                {
                    attackStart = Time.time;
                    attackReady = true;
                }
                return attackReady && Target != null && Vector3.Distance(this.Position, Target.Position) < 1.0f;
            }
        }


        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            if(this.IsSelected)
            {
                // Acknowledge clicked entity as a target for this unit
                if (target is Entity entity) //&& !entity.IsControllable())
                {
                    this.HasOrderFlag = true;
                    this.Target = entity;
                }

                if(target == null) // if unit or building gets destroyed
                {
                    this.HasOrderFlag = false;
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
            if(canAttack)
            {
                Attack(Target);
            }
        }

    }
}
