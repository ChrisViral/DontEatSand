using DontEatSand.Base;
using DontEatSand.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DontEatSand
{
    /// <summary>
    /// GameScenes
    /// </summary>
    public enum GameScenes
    {
        //If you add a scene to the game, make sure to add it, and add it's build index as the numerical value
        MENU = 0,
        WORLD = 1
    }

    /// <summary>
    /// Controls game wide related logic
    /// </summary>
    /// <inheritdoc/>
    [RequireComponent(typeof(AudioSource))]
    public class GameLogic : Singleton<GameLogic>
    {
        #region Fields
        //Inspector fields
        [SerializeField, Header("Music")]
        private AudioClip[] music;

        //Private fields
        private AudioSource source;
        private float baseVolume;
        #endregion

        #region Static properties
        /// <summary>
        /// Current loaded scene
        /// </summary>
        public static GameScenes LoadedScene { get; private set; }

        private static bool isPaused;
        /// <summary>
        /// If the game is currently paused
        /// </summary>
        public static bool IsPaused
        {
            get => isPaused;
            internal set
            {
                //Check if the value has changed
                if (isPaused != value)
                {
                    //Set value and stop Unity time
                    isPaused = value;
                    Time.timeScale = isPaused ? 0f : 1f;

                    //Log current state
                    Instance.Log($"Game {(isPaused ? "paused" : "unpaused")}");

                    //Fire pause event
                    GameEvents.OnPause.Invoke(isPaused);
                }
            }
        }

        /// <summary>
        /// Gets or sets the master volume of the game
        /// </summary>
        public static float MasterVolume
        {
            get => AudioListener.volume;
            internal set => AudioListener.volume = Mathf.Clamp01(value);
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Loads a given scene
        /// </summary>
        /// <param name="scene">Scene to load</param>
        internal static void LoadScene(GameScenes scene) => SceneManager.LoadScene((int)scene);

        /// <summary>
        /// Reloads the current scene
        /// </summary>
        internal static void ReloadScene() => LoadScene(LoadedScene);

        /// <summary>
        /// Closes the instance of the game, regardless of the current play mode
        /// </summary>
        internal static void Quit()
        {
            Instance.Log("Quitting game...");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// Plays the game music
        /// </summary>
        public static void PlayMusic() => Instance.source.Play();

        /// <summary>
        /// Pauses the game music
        /// </summary>
        public static void PauseMusic() => Instance.source.Pause();

        /// <summary>
        /// Stops the game music
        /// </summary>
        public static void StopMusic() => Instance.source.Stop();

        public static void SetMusic(AudioClip clip) => Instance.source.clip = clip;

        /// <summary>
        /// Sets the music volume to the given value
        /// </summary>
        /// <param name="volume">Volume to set the music to</param>
        public static void SetVolume(float volume) => Instance.source.volume = volume * Instance.baseVolume;
        #endregion

        #region Methods
        /// <summary>
        /// Game scene loaded event
        /// </summary>
        /// <param name="scene">Loaded scene</param>
        /// <param name="mode">Load mode</param>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //Get scene from build index
            GameScenes loadedScene = (GameScenes)scene.buildIndex;

            //Play level music if possible
            if (this.music.Length > scene.buildIndex)
            {
                AudioClip clip = this.music[scene.buildIndex];
                if (clip != null)
                {
                    this.source.clip = clip;
                    this.source.Play();
                    this.source.volume = this.baseVolume;
                }
            }

            //Make sure the game does not stay paused in the menu
            if (loadedScene == GameScenes.MENU)
            {
                IsPaused = false;
            }

            //Log scene change
            this.Log($"Scene loaded - {EnumUtils.GetNameCamelCase(loadedScene)}");
            GameScenes from = LoadedScene;
            LoadedScene = loadedScene;

            //Fire scene load event
            GameEvents.OnSceneLoaded.Invoke(from, loadedScene);
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Opening message
            this.Log("Running Don't Eat Sand v" + GameVersion.VersionString);

            //Add scene load event
            SceneManager.sceneLoaded += OnSceneLoaded;

            //Setup audio
            this.source = GetComponent<AudioSource>();
            this.source.loop = true;
            this.baseVolume = this.source.volume;
            XKCDColours.Init();
        }

        private void Update()
        {
            //Pauses the game
            if (LoadedScene == GameScenes.WORLD && InputUtils.Pause)
            {
                IsPaused = !IsPaused;
            }
        }

        //Make sure to remove events
        private void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;
        #endregion
    }
}
