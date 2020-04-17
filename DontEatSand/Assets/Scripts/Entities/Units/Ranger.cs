﻿using DontEatSand.Utils;
using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Ranger : Unit
    {
        #region Fields
        [SerializeField]
        private Vector3 launchLocation;
        [SerializeField]
        private Projectile projectile;
        // 0 die sound
        [SerializeField, Header("Sound Effect")]
        private AudioClip[] soundEffect;
        private AudioSource source;
        #endregion

        #region Methods
        protected override void ProcessCommand(Vector3 destination, ISelectable target)
        {
            //FROM CHRIS:
            //Just testing out the projectile, I don't know if this is actually good for BehaviourTree implementation
            base.ProcessCommand(destination, target);

            if(this.IsSelected)
            {
                this.HasOrderFlag = true;
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
            PhotonUtils.Instantiate(this.projectile, this.transform.TransformPoint(this.launchLocation)).Target = target;
            
        }
        #endregion

        #region Properties
        public override bool CanAttack
        {
            get
            {
                bool attackReady = false;
                if(Time.time > this.attackStart + this.attackInterval)
                {
                    this.attackStart = Time.time;
                    attackReady = true;
                }
                return attackReady && this.Target != null && Vector3.Distance(this.Position, this.Target.Position) < 10.0f;
            }
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            base.OnAwake();

            // Set throwing animation trigger
            this.attackTriggerName = Animator.StringToHash("Throwing");
        }

        protected override void OnUpdate()
        {
            if(this.CanAttack && this.Target)
            {
                Attack(this.Target);
            }
        }
        #endregion
    }
}
