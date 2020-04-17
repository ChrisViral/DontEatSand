using System;
using System.Linq;
using DontEatSand.Base;
using DontEatSand.Entities;
using DontEatSand.Entities.Buildings;
using DontEatSand.Extensions;
using DontEatSand.UI;
using DontEatSand.Utils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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
    public class GameLogic : SingletonPunCallbacks<GameLogic>
    {
        #region Constants
        /// <summary>
        /// The maximum amount of players in a game
        /// </summary>
        public const byte MAX_PLAYERS = 2;
        #endregion

        #region Fields
        //Inspector fields
        [SerializeField, Header("Music")]
        private AudioClip[] music;

        //Private fields
        private AudioSource source;
        private float baseVolume;
        private bool loaded;
        private int playerIndex;
        private Player otherPlayer;
        private Castle[] castles;
        #endregion

        #region Properties
        /// <summary>
        /// The castle associated to this player
        /// </summary>
        public Castle Castle { get; private set; }
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
                    isPaused = value;
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
        internal static void LoadScene(GameScenes scene)
        {
            //If networked, load through Photon
            if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
            {
                //Only loads the scene if on master client
                if (PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.LoadLevel((int)scene);
                }
            }
            //If not networked, load scene normally
            else { SceneManager.LoadScene((int)scene); }
        }

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

        /// <summary>
        /// Sets the music to the specified clip
        /// </summary>
        /// <param name="clip">Clip to change the music to</param>
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

            switch (loadedScene)
            {
                case GameScenes.MENU:
                    //Make sure the game does not stay paused in the menu
                    IsPaused = false;

                    //First time loading of the menu
                    if (!this.loaded)
                    {
                        FindObjectOfType<MainMenu>().SetupMenu();
                        this.loaded = true;
                    }

                    break;
                case GameScenes.WORLD:
                    this.castles = FindObjectsOfType<Castle>();
                    Array.Sort(this.castles);
                    break;
            }
            if (loadedScene == GameScenes.MENU)
            {
            }

            //Log scene change
            this.Log($"Scene loaded - {EnumUtils.GetNameCamelCase(loadedScene)}");
            GameScenes from = LoadedScene;
            LoadedScene = loadedScene;

            //Fire scene load event
            GameEvents.OnSceneLoaded.Invoke(from, loadedScene);
        }

        private void StartGame()
        {
            //Shortcut since we know we only have two players
            if (Random.value > 0.5f)
            {
                this.playerIndex = 0;
                this.photonView.RPC(nameof(SetPlayerIndex), this.otherPlayer, 1);
            }
            else
            {
                this.playerIndex = 1;
                this.photonView.RPC(nameof(SetPlayerIndex), this.otherPlayer, 0);
            }

            SetupPlayer();
        }

        [PunRPC]
        private void SetPlayerIndex(int index)
        {
            this.playerIndex = index;
            SetupPlayer();
        }

        private void SetupPlayer()
        {
            this.Castle = this.castles[this.playerIndex];
            this.Castle.photonView.RequestOwnership();
            this.castles.ForEach(c => c.enabled = true);
            RTSPlayer.Instance.enabled = true;
        }
        #endregion

        #region Callbacks
        public override void OnPlayerEnteredRoom(Player player)
        {
            this.Log(player.NickName + " just entered the room");
            if (PhotonNetwork.IsMasterClient)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == MAX_PLAYERS)
                {
                    StartGame();
                    this.otherPlayer = player;
                }
            }
            else
            {
                //Get other player
                this.otherPlayer = PhotonNetwork.PlayerListOthers[0];
            }
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            this.Log(other.NickName + " left the room");
            if (PhotonNetwork.IsMasterClient)
            {
                //Return to menu
                PhotonNetwork.DestroyAll();
                ReloadScene();
            }
        }

        public override void OnLeftRoom()
        {
            //Return to main menu
            this.Log("Left room, returning to menu...");
            PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
            LoadScene(GameScenes.MENU);
        }
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Opening message
            this.Log("Running Don't Eat Sand v" + GameVersion.VersionString);

            //Add scene load event
            SceneManager.sceneLoaded += OnSceneLoaded;

            //Setup PhotonNetwork
            PhotonNetwork.GameVersion = GameVersion.VersionString;
            PhotonNetwork.AutomaticallySyncScene = true;

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
