using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI
{
    public class TooltipChange : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Text unitName;
        [SerializeField]
        private Text cost;
        [SerializeField]
        private Text description;
        #endregion

        #region Methods
        /// <summary>
        /// Changes the tooltip info given a certain key
        /// </summary>
        /// <param name="key">Key of the unit/building to look up in the database</param>
        public void ChangeTooltip(string key)
        {
            UnitInfo unitInfo = UnitDatabase.GetInfo(key);
            this.unitName.text = unitInfo.Name;
            this.cost.text = unitInfo.CandyCost.ToString();
            this.description.text = unitInfo.Description;
        }
        #endregion
    }
}

