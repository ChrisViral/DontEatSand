using Photon.Pun;

namespace DontEatSand.Extensions
{
    /// <summary>
    /// Photon Network extension methods
    /// </summary>
    public static class PhotonExtensions
    {
        #region Extension methods
        /// <summary>
        /// Checks if a networked object is locally controllable
        /// </summary>
        /// <param name="obj">The networked object to check</param>
        /// <returns>True if the network is disconnected, or if the PhotonView is local</returns>
        public static bool IsControllable(this MonoBehaviourPun obj) => !PhotonNetwork.IsConnected || (obj.photonView.IsMine && obj.photonView.Owner != null);
        #endregion
    }
}
