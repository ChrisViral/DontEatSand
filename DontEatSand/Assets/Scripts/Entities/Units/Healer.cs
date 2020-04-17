using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Healer : Unit
    {
        
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
