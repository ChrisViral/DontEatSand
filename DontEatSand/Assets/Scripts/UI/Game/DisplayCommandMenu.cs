using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DontEatSand;
using DontEatSand.Entities;
using DontEatSand.Entities.Units;

namespace DontEatSand.UI
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
                //List<Unit> selected = RTSPlayer.Instance.SelectedUnits;

            }
            if(selection == SelectionType.OTHER)
            {
                ShowCastleCommands();
                Entity selected = (Entity) RTSPlayer.Instance.Selected;
            }
        }


        private void ShowUnitCommands()
        {
            unitCommands.SetActive(true);
            castleCommands.SetActive(false);
        }

        private void ShowCastleCommands()
        {
            unitCommands.SetActive(false);
            castleCommands.SetActive(true);
        }
        #endregion

        #region Functions
        private void Awake() => GameEvents.OnSelectionChanged.AddListener(ShowAvailableCommands);
        #endregion
    }
}

