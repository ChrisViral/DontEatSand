using UnityEngine;

namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Class behaviour specific to the soldier unit (or similar)
    /// </summary>
    public class Bully : Unit
    {
        #region Methods
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
         {
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
            if (target != this)
            {
                base.Attack(target);

                // index 1 attack sound
                PlaySoundOnce(1);

                target.Damage(10);

                if(target is Unit unit) // attacking a unit
                {
                    unit.IsUnderAttackFlag = true;
                    // index 2 hit on unit sound
                    PlaySoundOnce(2, 0.1f);
                }
                else // attacking a building
                {
                    // index 3 hit on building sound
                    PlaySoundOnce(3, 0.1f);
                }
            }
        }
        #endregion

        #region Functions
        protected override void OnUpdate()
        {
            if(this.CanAttack && this.Target != null)
            {
                Attack(this.Target);
            }
        }
        #endregion
    }

}
