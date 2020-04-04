using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand
{
    public class TooltipChange : MonoBehaviour
    {

        #region Properties

        [SerializeField]
        private Text name;
        [SerializeField]
        private Text cost;
        [SerializeField]
        private Text description;

        #endregion

        /// <summary>
        /// Changes the tooltip info given a certain key
        /// </summary>
        /// <param name="name">Key of the unit/building to look up in the database</param>
        public void ChangeTooltip(string key)
        {
            UnitInfo unitInfo = UnitDatabase.GetInfo(key);
            name.text = unitInfo.Name;
            cost.text = unitInfo.CandyCost.ToString();
            description.text = unitInfo.Description;
        }
    
    }
}

