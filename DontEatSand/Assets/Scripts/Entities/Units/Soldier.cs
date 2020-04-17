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
        [SerializeField, Header("Sound Effect")]
        private AudioClip[] soundEffect;
        private AudioSource source;

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

            if (soundEffect.Length > 0)
            {
                source.PlayOneShot(soundEffect[1]);
            }

            target.Damage(10);

            if(target is Unit unit) // attacking a unit
            {
                unit.IsUnderAttackFlag = true;

                if (soundEffect.Length > 0)
                {// sound of hit on unit
                    source.clip = soundEffect[2];
                    source.PlayDelayed(0.1f);
                }
            }
            else // attacking a building
            {

                if (soundEffect.Length > 0)
                {// sound of hit on building
                    source.clip = soundEffect[3];
                    source.PlayDelayed(0.1f);
                }
            }
        }


        protected override void OnAwake()
        {
            base.OnAwake();

            // Setup audio
            this.source = GetComponent<AudioSource>();
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

        protected override void OnDestroyed()
        {
            if (soundEffect.Length > 0)
            {
                source.PlayOneShot(soundEffect[0]);
            }
            base.OnDestroyed();
        }
        #endregion
    }
}
