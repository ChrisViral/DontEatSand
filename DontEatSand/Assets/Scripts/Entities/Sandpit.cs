using System;
using DontEatSand.Base;
using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Entities
{
    /// <summary>
    /// Wet sand deposit
    /// </summary>
    public class Sandpit : Discoverable, ISelectable
    {
        #region Fields
        [SerializeField]
        private Renderer selectionIndicator;
        [SerializeField]
        private Color selectedColour = Color.green, hoveredColour = Color.blue;
        #endregion

        #region Properties
        [SerializeField]
        private int availableSand = 1000;
        /// <summary>
        /// Available sand in this pit
        /// </summary>
        public int AvailableSand => this.availableSand;

        private bool isSelected;
        /// <summary>
        /// If this Sandpit is currently selected or not
        /// </summary>
        public bool IsSelected
        {
            get => this.isSelected;
            set
            {
                //On value change
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    if (this.isSelected)
                    {
                        //If selected, activate and colour
                        this.selectionIndicator.gameObject.SetActive(true);
                        this.selectionIndicator.material.color = this.selectedColour;
                    }
                    else
                    {
                        if (this.isHovered)
                        {
                            //If not active but hovered, set as hovered colour
                            this.selectionIndicator.material.color = this.hoveredColour;
                        }
                        else
                        {
                            //If not hovered, turn off
                            this.selectionIndicator.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        private bool isHovered;
        /// <summary>
        /// If this Sandpit is currently being hovered or not
        /// </summary>
        public bool IsHovered
        {
            get => this.isHovered;
            set
            {
                //On value change
                if (this.isHovered != value)
                {
                    this.isHovered = value;
                    //Only update if not selected
                    if (!this.IsSelected)
                    {
                        if (this.isHovered)
                        {
                            //If hovered, turn on and colour
                            this.selectionIndicator.gameObject.SetActive(true);
                            this.selectionIndicator.material.color = this.hoveredColour;
                        }
                        else
                        {
                            //Else turn off
                            this.selectionIndicator.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
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
