using DontEatSand.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class DisplayHealthAndIcon : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject greenHealth;
        #endregion

        #region Properties
        /// <summary>
        /// The unit whose icon and health we want to show
        /// </summary>
        public Entity EntityToDisplay { get; set; }
        #endregion

        #region Functions
        private void Update()
        {
            if(this.EntityToDisplay)
            {
                this.greenHealth.GetComponent<Image>().fillAmount = EntityToDisplay.Health / EntityToDisplay.HealthAmount;
                GetComponent<Image>().sprite = EntityToDisplay.Info.Icon;
            }
        }
        #endregion
    }
}


