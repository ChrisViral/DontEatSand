using UnityEngine;
using UnityEngine.AI;
using DontEatSand.Entities;
using DontEatSand.Extensions;
using DontEatSand.Entities.Buildings;


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
                HasOrderFlag = true;
                Target = entity;
                Attack(Target);
            }

            if(target == null) // if unit or building gets destroyed
            {
                HasOrderFlag = false;
            }

        }

        public override void Attack(Entity target)
        {
            if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
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
