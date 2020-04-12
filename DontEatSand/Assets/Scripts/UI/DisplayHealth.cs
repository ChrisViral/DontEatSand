using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities.Units;

namespace DontEatSand.UI
{
    public class DisplayHealth : MonoBehaviour
    {
        /// <summary>
        /// The unit whose health we want to show
        /// </summary>
        private Unit unitToDisplay;
        [SerializeField]
        private GameObject greenHealth;

        private void Start()
        {
            unitToDisplay = null;
        }

        private void Update()
        {
            if(unitToDisplay)
            {
                Debug.Log("Displaying health");
                greenHealth.GetComponent<Image>().fillAmount = 100f / 200f;
            }
        }

        public void SetUnitToDisplay(Unit unit)
        {
            unitToDisplay = unit;
        }
    }
}


