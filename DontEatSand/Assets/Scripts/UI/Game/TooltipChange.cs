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
            this.description.text = $"Sand: {unitInfo.SandCost}\nCandy: {unitInfo.CandyCost}\n{unitInfo.Description}";
        }

        /// <summary>
        /// Displays a custom title
        /// </summary>
        /// <param name="text">Title to display</param>
        public void CustomTitle(string text) => this.title.text = text;

        /// <summary>
        /// Displays a custom description
        /// </summary>
        /// <param name="desc">Description to display</param>
        public void CustomDescription(string desc) => this.description.text = desc;
        #endregion
    }
}

