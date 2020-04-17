using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    public class Soldier : Unit
    {

        // 0 die sound
        // 1 attack sound
        // 2 hit on unit
        // 3 hit on building
        [SerializeField, Header("Sound Effect")]
        private AudioClip[] soundEffect;
        private AudioSource source;

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
            if(CanAttack)
            {
                Attack(Target);
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

    }
}
