using UnityEngine;
using System.Collections.Generic;
     
namespace DontEatSand.Entities.Units
{
    public class Healer : Unit
    {
        #region Fields
        [SerializeField]
        private GameObject projectile;
        private readonly HashSet<Unit> allyUnitsInRange = new HashSet<Unit>();
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

        #region Methods

        /// <summary>
        /// Find the closest enemy unit to this unit
        /// </summary>
        /// <returns></returns>
        private Unit FindClosestTarget()
        {
            int size = this.allyUnitsInRange.Count;
            if (size == 0) return null;

            //Get closest target
            Unit closestTarget = null;
            Vector3 position = this.transform.position;
            float distanceToClosest = float.PositiveInfinity;
            foreach (Unit ally in this.allyUnitsInRange)
            {
                float dist = Vector3.Distance(ally.Position, position);
                //Making sure it's a valid entity target
                if(dist < distanceToClosest) // && (!PhotonNetwork.IsConnected || !entity.photonView.IsMine))
                {
                    distanceToClosest = dist;
                    closestTarget = ally;
                }
            }

            //Return it's entity
            return closestTarget;
        }

        #endregion

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

        protected override void OnAwake()
        {
            base.OnAwake();
            
            // Set throwing animation trigger
            attackTriggerName = Animator.StringToHash("Throwing");
        }
        #endregion

        #region Collider Functions
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit allyUnit)) // && !enemyUnit.IsControllable())
            {
                // Populate enemies
                this.allyUnitsInRange.Add(allyUnit);
            }

        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.isTrigger) { return; }

            if(collider.transform.parent.TryGetComponent(out Unit allyUnit) && this.allyUnitsInRange.Contains(allyUnit))
            {
                this.allyUnitsInRange.Remove(allyUnit);
            }
        }
        #endregion

    }
}
