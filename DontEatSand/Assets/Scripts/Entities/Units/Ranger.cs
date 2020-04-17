using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Ranger : Unit
    {
        #region Fields
        [SerializeField]
        private GameObject projectile;
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            base.OnAwake();
            
            // Set throwing animation trigger
            attackTriggerName = Animator.StringToHash("Throwing");
        }
        #endregion
    }
}
