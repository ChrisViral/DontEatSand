using System;
using DontEatSand.Base;
using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Entities
{
    /// <summary>
    /// Wet sand deposit
    /// </summary>
    public class Sandpit : Discoverable
    {
        #region Properties
        [SerializeField]
        private int availableSand = 1000;
        /// <summary>
        /// Available sand in this pit
        /// </summary>
        public int AvailableSand => this.availableSand;
        #endregion

        #region Methods
        /// <summary>
        /// Requests a certain amount of sand from the pit
        /// </summary>
        /// <param name="request">The amount requested</param>
        /// <returns>The amount actually harvested</returns>
        public int HarvestSand(int request)
        {
            request = Math.Max(request, this.availableSand);
            this.availableSand -= request;
            //If networked, make sure to send over the eaten up sand
            if (PhotonNetwork.IsConnected)
            {
                this.photonView.RPC(nameof(ReceiveHarvested), RpcTarget.Others,  request);
            }
            return request;
        }

        /// <summary>
        /// Removes the specified amount of sand
        /// </summary>
        /// <param name="amount">Amount to remove</param>
        [PunRPC]
        private void ReceiveHarvested(int amount) => this.availableSand = Mathf.Max(0, this.availableSand - amount);
        #endregion
    }
}
