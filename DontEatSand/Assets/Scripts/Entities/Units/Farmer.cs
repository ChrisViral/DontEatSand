using UnityEngine;

namespace DontEatSand.Entities.Units
{
    public class Farmer : Unit
    {
        #region Constants
        /// Animator dig trigger name
        /// </summary>
        private int digTriggerName = Animator.StringToHash("Digging");
        /// Animator build trigger name
        /// </summary>
        private int buildTriggerName = Animator.StringToHash("Building");
        #endregion
        
    }
}
