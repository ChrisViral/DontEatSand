using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class TooltipChange : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Text title;
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
            this.title.text = unitInfo.Name;
            this.description.text = string.Format("Sand: {0}\nCandy: {1}\n{2}", unitInfo.SandCost, unitInfo.CandyCost, unitInfo.Description);
        }

        /// <summary>
        /// Displays a custom title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public void CustomTitle(string title)
        {
            this.title.text = title;
        }

        /// <summary>
        /// Displays a custom description
        /// </summary>
        /// <param name="desc"></param>
        public void CustomDescription(string desc)
        {
            this.description.text = desc;
        }

        #endregion
    }
}

