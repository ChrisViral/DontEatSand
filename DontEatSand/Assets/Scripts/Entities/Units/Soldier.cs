using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    /// <summary>
    /// Class behaviour specific to the soldier unit (or similar)
    /// </summary>
    public class Soldier : Unit
    {
        // 0 die sound
        // 1 attack sound
        // 2 hit on unit
        // 3 hit on building
        //[SerializeField, Header("Sound Effect")]
        //private AudioClip[] soundEffect;
        //private AudioSource source;

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
            base.Attack(target);

            PlaySoundOnce(1);

            target.Damage(10);

            if(target is Unit unit) // attacking a unit
            {
                unit.IsUnderAttackFlag = true;
                
                PlaySoundOnce(2, 0.1f);
            }
            else // attacking a building
            {
                PlaySoundOnce(3, 0.1f);
                
            }
        }

        #endregion

        #region Functions
        protected override void OnUpdate()
        {
            // if target exists and is within range
            if(CanAttack && Target != null)
            {
                Attack(Target);
            }
        }
        #endregion
    }
}
