using UnityEngine;
using UnityEngine.AI;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Class behaviour specific to the soldier unit (or similar)
    /// </summary>
    public class Bully : Unit
    {
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
        #endregion
    }

}
