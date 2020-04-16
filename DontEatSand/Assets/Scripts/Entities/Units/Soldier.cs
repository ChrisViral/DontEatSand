using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    public class Soldier : Unit
    {

        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            base.ProcessCommand(destination, target);

            // Attack unit if it's an enemy
            if (target is Entity entity) //&& !entity.IsControllable())
            {
                this.HasOrderFlag = true;
                this.Target = entity;
                Attack(this.Target);
            }

            if(target == null) // if unit or building gets destroyed
            {
                this.HasOrderFlag = false;
            }

        }

        public override void Attack(Entity target)
        {
            if (this.agent.pathStatus == NavMeshPathStatus.PathComplete)
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
        }

    }
}
