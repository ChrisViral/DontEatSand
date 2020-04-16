using Photon.Pun;
using UnityEngine;

namespace DontEatSand.UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private GameObject pauseMenu;
        #endregion

        #region Methods
        /// <summary>
        /// OnPause event
        /// </summary>
        /// <param name="state">Pause state</param>
        private void OnPause(bool state) => this.pauseMenu.SetActive(state);

        /// <summary>
        /// Resumes the game
        /// </summary>
        public void Resume() => GameLogic.IsPaused = false;

        /// <summary>
        /// Quits to the main menu
        /// </summary>
        public void Return()
        {
            if (PhotonNetwork.IsConnected) { PhotonNetwork.LeaveRoom(); }
            else { GameLogic.LoadScene(GameScenes.MENU); }
        }
        #endregion

        #region Functions
        //Add event
        private void Awake() => GameEvents.OnPause.AddListener(OnPause);

        //Remove event
        private void OnDestroy() => GameEvents.OnPause.RemoveListener(OnPause);
        #endregion
    }
}
