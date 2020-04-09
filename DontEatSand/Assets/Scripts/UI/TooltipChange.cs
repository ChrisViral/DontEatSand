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
        private Text sandCost;
        [SerializeField]
        private Text candyCost;
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
            this.sandCost.text = string.Format("Sand: {0}", unitInfo.SandCost);
            this.candyCost.text = string.Format("Candy: {0}", unitInfo.CandyCost);
            this.description.text = unitInfo.Description;
        }
        #endregion
    }
}

