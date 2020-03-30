using UnityEngine;

namespace DontEatSand.UI
{
    [RequireComponent(typeof(Animator))]
    public class MainMenu : MonoBehaviour
    {
        #region Constants
        private static readonly int options = Animator.StringToHash("Options");
        #endregion

        #region Fields
        private Animator animator;
        #endregion

        #region Methods
        /// <summary>
        /// Resumes the game
        /// </summary>
        public void StartGame() => GameLogic.LoadScene(GameScenes.WORLD);

        /// <summary>
        /// Fades to the option menu
        /// </summary>
        public void OptionsMenu() => this.animator.SetBool(options, true);

        /// <summary>
        /// Fades back to the main menu
        /// </summary>
        public void Back() => this.animator.SetBool(options, false);

        /// <summary>
        /// Quits to the main menu
        /// </summary>
        public void Quit() => GameLogic.Quit();

        /// <summary>
        /// Sets the master volume of the game
        /// </summary>
        /// <param name="volume">New volume to set</param>
        public void OnVolumeChanged(float volume) => GameLogic.MasterVolume = volume;
        #endregion

        #region Functions
        private void Awake() => this.animator = GetComponent<Animator>();
        #endregion
    }
}
