using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class DisplayHealth : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject greenHealth;
        #endregion

        #region Properties
        /// <summary>
        /// The unit whose health we want to show
        /// </summary>
        public Unit UnitToDisplay { get; set; }
        #endregion

        #region Functions
        private void Update()
        {
            if(this.UnitToDisplay)
            {
                Debug.Log("Displaying health");
                this.greenHealth.GetComponent<Image>().fillAmount = 100f / 200f;
            }
        }
        #endregion
    }
}


