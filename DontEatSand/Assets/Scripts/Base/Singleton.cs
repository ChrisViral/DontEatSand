using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace DontEatSand.Base
{
    /// <summary>
    /// Singleton base class
    /// </summary>
    /// <typeparam name="T">MonoBehaviour type</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        #region Instance
        /// <summary>
        /// Single immortal instance of this object
        /// </summary>
        public static T Instance { get; private set; }
        #endregion

        #region Properties
        /// <summary>
        /// If this Singleton instance persists through scenes
        /// </summary>
        protected virtual bool Immortal { get; } = true;
        #endregion

        #region Virtual methods
        /// <summary>
        /// This is called from within Awake, you should override this instead of writing an Awake() method
        /// </summary>
        protected virtual void OnAwake() { }
        #endregion

        #region Functions
        private void Awake()
        {
            //Check for an existing instance
            if (Instance)
            {
                Destroy(this.gameObject);
                return;
            }

            //If none exist, create it
            Instance = this as T;
            if (this.Immortal)
            {
                DontDestroyOnLoad(this.gameObject);
            }

            //Call children Awake()
            OnAwake();
        }
        #endregion
    }

    /// <summary>
    /// Singleton class mimicking MonoBehaviourPunCallbacks
    /// </summary>
    /// <typeparam name="T">MonoBehaviour type</typeparam>
    public abstract class SingletonPunCallbacks<T> : Singleton<T>, IConnectionCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, ILobbyCallbacks, IWebRpcCallback where T : SingletonPunCallbacks<T>
    {
        #region Static fields
        /// <summary>
        /// Keeps track of distributed IDs to Singletons
        /// </summary>
        //ReSharper disable once StaticMemberInGenericType
        private static int lastID = 999;
        #endregion

        #region Properties
        //ReSharper disable InconsistentNaming
        private PhotonView _photonView;
        /// <summary>
        /// Cached reference to the PhotonView of this object
        /// </summary>
        public PhotonView photonView
        {
            get
            {
                if (!this._photonView)
                {
                    this._photonView = PhotonView.Get(this);
                }

                return this._photonView;
            }
        }
        //ReSharper enable InconsistentNaming
        #endregion

        #region Callbacks
        /// <inheritdoc cref="IConnectionCallbacks.OnConnected"/>
        public virtual void OnConnected() { }

        /// <inheritdoc cref="IConnectionCallbacks.OnConnectedToMaster"/>
        public virtual void OnConnectedToMaster() { }

        /// <inheritdoc cref="IConnectionCallbacks.OnDisconnected"/>
        public virtual void OnDisconnected(DisconnectCause cause) { }

        /// <inheritdoc cref="IConnectionCallbacks.OnRegionListReceived"/>
        public virtual void OnRegionListReceived(RegionHandler regionHandler) { }

        /// <inheritdoc cref="IConnectionCallbacks.OnCustomAuthenticationResponse"/>
        public virtual void OnCustomAuthenticationResponse(Dictionary<string, object> data) { }

        /// <inheritdoc cref="IConnectionCallbacks.OnCustomAuthenticationFailed"/>
        public virtual void OnCustomAuthenticationFailed(string debugMessage) { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnFriendListUpdate"/>
        public virtual void OnFriendListUpdate(List<FriendInfo> friendList) { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnCreatedRoom"/>
        public virtual void OnCreatedRoom() { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnCreateRoomFailed"/>
        public virtual void OnCreateRoomFailed(short returnCode, string message) { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnJoinedRoom"/>
        public virtual void OnJoinedRoom() { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnJoinRoomFailed"/>
        public virtual void OnJoinRoomFailed(short returnCode, string message) { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnJoinRandomFailed"/>
        public virtual void OnJoinRandomFailed(short returnCode, string message) { }

        /// <inheritdoc cref="IMatchmakingCallbacks.OnLeftRoom"/>
        public virtual void OnLeftRoom() { }

        /// <inheritdoc cref="IInRoomCallbacks.OnPlayerEnteredRoom"/>
        public virtual void OnPlayerEnteredRoom(Player newPlayer) { }

        /// <inheritdoc cref="IInRoomCallbacks.OnPlayerLeftRoom"/>
        public virtual void OnPlayerLeftRoom(Player otherPlayer) { }

        /// <inheritdoc cref="IInRoomCallbacks.OnRoomPropertiesUpdate"/>
        public virtual void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) { }

        /// <inheritdoc cref="IInRoomCallbacks.OnPlayerPropertiesUpdate"/>
        public virtual void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) { }

        /// <inheritdoc cref="IInRoomCallbacks.OnMasterClientSwitched"/>
        public virtual void OnMasterClientSwitched(Player newMasterClient) { }

        /// <inheritdoc cref="ILobbyCallbacks.OnJoinedLobby"/>
        public virtual void OnJoinedLobby() { }

        /// <inheritdoc cref="ILobbyCallbacks.OnLeftLobby"/>
        public virtual void OnLeftLobby() { }

        /// <inheritdoc cref="ILobbyCallbacks.OnRoomListUpdate"/>
        public virtual void OnRoomListUpdate(List<RoomInfo> roomList) { }

        /// <inheritdoc cref="ILobbyCallbacks.OnLobbyStatisticsUpdate"/>
        public virtual void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) { }

        /// <inheritdoc cref="IWebRpcCallback.OnWebRpcResponse"/>
        public virtual void OnWebRpcResponse(OperationResponse response) { }
        #endregion

        #region Functions
        /// <summary>
        /// Awake Unity function. MakeSure to call base.OnAwake if overridingde
        /// </summary>
        protected override void OnAwake()
        {
            if (this.Immortal)
            {
                //Make sure we have a unique PhotonView since this object will persist through scenes
                if (!this.photonView)
                {
                    this.gameObject.AddComponent<PhotonView>();
                }
                this.photonView.ViewID = lastID--;
            }
        }

        /// <summary>
        /// OnEnable Unity function. Make sure to call base.OnEnable() if overriding
        /// </summary>
        protected virtual void OnEnable() => PhotonNetwork.AddCallbackTarget(this);

        /// <summary>
        /// OnDisable Unity function. Make sure to call base.OnDisable() if overriding
        /// </summary>
        protected virtual void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);
        #endregion
    }
}
