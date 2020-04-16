using DontEatSand.Entities;
using UnityEngine;

namespace DontEatSand.UI.Game
{
    public class DisplayCommandMenu : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject unitCommands;
        [SerializeField]
        private GameObject castleCommands;
        #endregion

        #region Methods
        /// <summary>
        /// Shows the commands available based on the selection type
        /// </summary>
        /// <param name="selection"></param>
        private void ShowAvailableCommands(SelectionType selection)
        {
            // TODO: add references to units so that we can pass commands to each unit
            if(selection == SelectionType.UNITS)
            {
                ShowUnitCommands();
                //SortedSet<Unit> selected = RTSPlayer.Instance.SelectedUnits;

            }
            if(selection == SelectionType.OTHER)
            {
                ShowCastleCommands();
                //Entity selected = (Entity)RTSPlayer.Instance.Selected;
            }
        }

        private void ShowUnitCommands()
        {
            this.unitCommands.SetActive(true);
            this.castleCommands.SetActive(false);
        }

        private void ShowCastleCommands()
        {
            this.unitCommands.SetActive(false);
            this.castleCommands.SetActive(true);
        }
        #endregion

        #region Functions
        private void Awake() => GameEvents.OnSelectionChanged.AddListener(ShowAvailableCommands);

        private void OnDestroy() => GameEvents.OnSelectionChanged.RemoveListener(ShowAvailableCommands);
        #endregion
    }
}

