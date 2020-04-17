using UnityEngine;
using UnityEngine.AI;


namespace DontEatSand.Entities.Units
{
    public class Soldier : Unit
    {
        #region Fields
        private float attackStart = 0f;
        private float attackInterval = 1.0f;

        // 0 attack sound
        // 1 hit on unit
        // 2 hit on building
        [SerializeField, Header("Sound Effect")]
        private AudioClip[] soundEffect;
        private AudioSource source;

        #endregion

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

            if (soundEffect.Length > 0)
            {
                source.PlayOneShot(soundEffect[0]);
            }

            target.Damage(10);
            if(target is Unit unit) // attacking a unit
            {
                unit.IsUnderAttackFlag = true;

                if (soundEffect.Length > 0)
                {// sound of hit on unit
                    source.clip = soundEffect[1];
                    source.PlayDelayed(0.1f);
                }
            }
            else // attacking a building
            {

                if (soundEffect.Length > 0)
                {// sound of hit on building
                    source.clip = soundEffect[2];
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
            if(canAttack)
            {
                Attack(Target);
            }
        }

    }
}
