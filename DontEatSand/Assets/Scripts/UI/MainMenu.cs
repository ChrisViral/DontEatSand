using UnityEngine;

namespace DontEatSand.UI
{
    public class MainMenu : MonoBehaviour
    {
        #region Methods
        /// <summary>
        /// Resumes the game
        /// </summary>
        public void StartGame() => GameLogic.LoadScene(GameScenes.WORLD);

        /// <summary>
        /// Quits to the main menu
        /// </summary>
        public void Quit() => GameLogic.Quit();
        #endregion
    }
}
