using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// PhotonNetwork utility methods
    /// </summary>
    public static class PhotonUtils
    {
        #region Properties
        /// <summary>
        /// Checks if Photon is connected and this client is the Master Client
        /// </summary>
        public static bool IsMaster => PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient;
        #endregion

        #region Static methods
        /// <summary>
        /// Instantiates the given Component prefab across the network if necessary
        /// </summary>
        /// <typeparam name="T">Type of Component to instantiate</typeparam>
        /// <param name="prefab">Component prefab to instantiate</param>
        /// <param name="position">Position of the instantiated prefab, defaults to Vector3.zero</param>
        /// <param name="rotation">Rotation of the instantiated prefab, defaults to Quaternion.identity</param>
        ///^<param name="parent">Parent to attach the prefab to, leave null to not attach to any parent</param>
        /// <returns>The instantiated Component</returns>
        public static T Instantiate<T>(T prefab, Vector3 position = default, Quaternion rotation = default, Transform parent = null) where T : Component
        {
            if (PhotonNetwork.IsConnected)
            {
                //Networked instantiation
                T clone = PhotonNetwork.Instantiate(prefab.gameObject.name, position, rotation).GetComponent<T>();
                if (parent)
                {
                    //Set the parent if necessary
                    clone.transform.SetParent(parent, true);
                }
            }
            //Local instantiation when not networked
            return Object.Instantiate(prefab, position, rotation, parent);
        }

        /// <summary>
        /// Instantiates the given GameObject prefab across the network if necessary
        /// </summary>
        /// <param name="prefab">GameObject prefab to instantiate</param>
        /// <param name="position">Position of the instantiated prefab, defaults to Vector3.zero</param>
        /// <param name="rotation">Rotation of the instantiated prefab, defaults to Quaternion.identity</param>
        ///^<param name="parent">Parent to attach the prefab to, leave null to not attach to any parent</param>
        /// <returns>The instantiated GameObject</returns>
        public static GameObject Instantiate(GameObject prefab, Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            if (PhotonNetwork.IsConnected)
            {
                //Networked instantiation
                GameObject clone = PhotonNetwork.Instantiate(prefab.name, position, rotation);
                if (parent)
                {
                    //Set the parent if necessary
                    clone.transform.SetParent(parent, true);
                }
            }
            //Local instantiation when not networked
            return Object.Instantiate(prefab, position, rotation, parent);
        }

        /// <summary>
        /// Destroys the given networked object
        /// </summary>
        /// <param name="obj">Object to destroy</param>
        public static void Destroy(MonoBehaviourPun obj)
        {
            if (PhotonNetwork.IsConnected)
            {
                //If networked, only destroy if owning
                if (obj.photonView.IsMine)
                {
                    PhotonNetwork.Destroy(obj.gameObject);
                }
            }
            //otherwise just destroy normally
            else { Object.Destroy(obj.gameObject); }
        }
        #endregion
    }
}
