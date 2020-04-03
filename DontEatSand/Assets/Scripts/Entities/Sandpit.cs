using System;
using DontEatSand.Base;
using UnityEngine;

namespace DontEatSand.Entities
{
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
            return request;
        }
        #endregion
    }
}
