using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI
{
    [RequireComponent(typeof(Animator))]
    public class MainMenu : MonoBehaviourPunCallbacks
    {
        #region Constants
        /// <summary>
        /// Default nickname of the player, also used as the PlayerPrefs nickname key
        /// </summary>
        private const string DEFAULT_NAME = "Player";
        /// <summary>
        /// Randomly created room options
        /// </summary>
        private static readonly RoomOptions randomOptions = new RoomOptions { MaxPlayers = GameLogic.MAX_PLAYERS };
        /// <summary>
        /// Custom created room options
        /// </summary>
        private static readonly RoomOptions createdOptions = new RoomOptions { MaxPlayers = GameLogic.MAX_PLAYERS, IsVisible = false };
        /// <summary>
        /// Options animator parameter hash
        /// </summary>
        private static readonly int menuParam = Animator.StringToHash("Menu");
        /// <summary>
        /// Options animator parameter hash
        /// </summary>
        private static readonly int optionsParam = Animator.StringToHash("Options");
        /// <summary>
        /// Nickname animator parameter hash
        /// </summary>
        private static readonly int nickParam = Animator.StringToHash("Nickname");
        /// <summary>
        /// Room animator parameter hash
        /// </summary>
        private static readonly int roomParam = Animator.StringToHash("Room");
        /// <summary>
        /// Connected trigger animator parameter hash
        /// </summary>
        private static readonly int connectedParam = Animator.StringToHash("Connected");
        /// <summary>
        /// Disabled text colour
        /// </summary>
        private static readonly Color disabledColour = new Color(0.3f, 0.3f, 0.3f);
        #endregion

        #region Fields
        [SerializeField]
        private Button connectButton, createButton;
        [SerializeField]
        private TMP_InputField nicknameField;
        [SerializeField]
        private TMP_Text errorText;
        [SerializeField]
        private GameObject connectingText;
        private TMP_Text connectButtonText, createButtonText;
        private string roomName;
        private Animator animator;
        private bool isConnecting;
        #endregion

        #region Methods
        /// <summary>
        /// Resumes the game
        /// </summary>
        public void Play()
        {
            this.animator.SetBool(nickParam, true);
            this.animator.SetBool(menuParam, false);
        }

        /// <summary>
        /// Returns to main menu from nickname selection
        /// </summary>
        public void NickBack()
        {
            this.animator.SetBool(nickParam, false);
            this.animator.SetBool(menuParam, true);
        }

        /// <summary>
        /// Connects to network and goes to room selection
        /// </summary>
        public void Connect()
        {
            this.isConnecting = PhotonNetwork.ConnectUsingSettings();
            if (this.isConnecting)
            {
                this.animator.SetBool(roomParam, true);
                this.animator.SetBool(nickParam, false);
                this.connectingText.SetActive(true);
            }
        }

        /// <summary>
        /// Disconnects from network and returns to nickname selection
        /// </summary>
        public void Disconnect() => PhotonNetwork.Disconnect();

        /// <summary>
        /// Fades to the option menu
        /// </summary>
        public void OptionsMenu()
        {
            this.animator.SetBool(optionsParam, true);
            this.animator.SetBool(menuParam, false);
        }

        /// <summary>
        /// Fades back to the main menu
        /// </summary>
        public void OptionsBack()
        {
            this.animator.SetBool(optionsParam, false);
            this.animator.SetBool(menuParam, false);
        }

        /// <summary>
        /// Joins a named room, or creates it if it does not exist
        /// </summary>
        public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(this.roomName, createdOptions, null);

        /// <summary>
        /// Joins a random room
        /// </summary>
        public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

        /// <summary>
        /// Quits to the main menu
        /// </summary>
        public void Quit() => GameLogic.Quit();

        /// <summary>
        /// Sets the master volume of the game
        /// </summary>
        /// <param name="volume">New volume to set</param>
        public void OnVolumeChanged(float volume) => GameLogic.MasterVolume = volume;

        /// <summary>
        /// Updates the nickname
        /// </summary>
        /// <param name="value">New nickname</param>
        public void OnNicknameChanged(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                PlayerPrefs.SetString(DEFAULT_NAME, value);
                PhotonNetwork.NickName = value;
                if (!this.connectButton.interactable)
                {
                    this.connectButton.interactable = true;
                    this.connectButtonText.color = Color.white;
                }
            }
            else if (this.connectButton.interactable)
            {
                this.connectButton.interactable = false;
                this.connectButtonText.color = disabledColour;
            }
        }

        /// <summary>
        /// Updates the room name
        /// </summary>
        /// <param name="value">New room name</param>
        public void OnRoomNameChanged(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                this.roomName = value;
                if (!this.createButton.interactable)
                {
                    this.createButton.interactable = true;
                    this.createButtonText.color = Color.white;
                }
            }
            else if (this.createButton.interactable)
            {
                this.createButton.interactable = false;
                this.createButtonText.color = disabledColour;
            }
        }

        /// <summary>
        /// Sets up the menu for first use
        /// </summary>
        internal void SetupMenu() => this.animator.SetBool(menuParam, true);
        #endregion

        #region Callbacks
        public override void OnConnectedToMaster()
        {
            //When connected to master, show the room creation
            this.Log("Connected to master server");
            if (this.isConnecting)
            {
                this.animator.SetTrigger(connectedParam);
                this.connectingText.SetActive(false);
            }
            else
            {
                //Returning from menu
                this.animator.SetBool(roomParam, true);
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            //If failed to join a random room, create one
            this.LogWarning($"Could not join random room\nCode {returnCode} - {message}");
            this.Log("Creating new room...");
            PhotonNetwork.CreateRoom(string.Empty, randomOptions);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            //If failed to join a random room, create one
            this.LogError($"Could not create room\nCode {returnCode} - {message}");
            this.errorText.text = "Could not create room: " + message;
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            //If failed to join a random room, create one
            this.LogError($"Could not join room\nCode {returnCode} - {message}");
            this.errorText.text = "Could not join room: " + message;
        }

        public override void OnJoinedRoom() => GameLogic.LoadScene(GameScenes.WORLD);

        public override void OnDisconnected(DisconnectCause cause)
        {
            //When disconnected, go back to original menu
            this.LogWarning("Disconnected from network\nReason: " + cause);
            this.animator.SetBool(roomParam, false);
            this.animator.SetBool(nickParam, true);
        }
        #endregion

        #region Functions
        private void Awake()
        {
            //Get components
            this.animator = GetComponent<Animator>();
            this.connectButtonText = this.connectButton.transform.GetChild(0).GetComponent<TMP_Text>();
            this.createButtonText = this.createButton.transform.GetChild(0).GetComponent<TMP_Text>();
            this.createButtonText.color = disabledColour;
            this.createButton.interactable = false;

            if (PlayerPrefs.HasKey(DEFAULT_NAME))
            {
                //Fetch previous nickname if one exists
                PhotonNetwork.NickName = this.nicknameField.text = PlayerPrefs.GetString(DEFAULT_NAME);
            }
            else
            {
                //Else set the default one
                PhotonNetwork.NickName = this.nicknameField.text = DEFAULT_NAME;
                PlayerPrefs.SetString(DEFAULT_NAME, DEFAULT_NAME);
            }
        }
        #endregion
    }
}
