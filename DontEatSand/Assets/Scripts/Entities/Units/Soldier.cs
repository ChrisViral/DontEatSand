using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    public class Soldier : Unit
    {
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
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
            if(CanAttack)
            {
                Attack(Target);
            }
        }

    }
}
