using DontEatSand.Utils;
using UnityEngine;

namespace DontEatSand.Base
{
    [DisallowMultipleComponent, RequireComponent(typeof(Collider))]
    public class Discoverable : MonoBehaviour
    {
        #region Fields
        [SerializeField, Tooltip("The layer to switch to")]
        private Layers switchLayer = Layers.DEFAULT;
        [SerializeField, Tooltip("If the discovery is permanent or not")]
        private bool permanent;
        private int inRange;
        #endregion

        #region Properties
        /// <summary>
        /// If the object is currently visible or not
        /// </summary>
        public bool Visible { get; private set; }
        #endregion

        #region Functions
        private void OnTriggerEnter(Collider other)
        {
            if (this.permanent)
            {
                //If invisible, make visible
                if (!this.Visible)
                {
                    this.gameObject.layer = (int)this.switchLayer;
                    this.Visible = true;
                }
            }
            else
            {
                //If invisible, make visible, and increment counter
                this.inRange++;
                if (!this.Visible)
                {
                    GameObject go = this.gameObject;
                    Layers temp = (Layers)go.layer;
                    go.layer = (int)this.switchLayer;
                    this.switchLayer = temp;
                    this.Visible = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //If visible and counter reaches zero, make invisible
            if (!this.permanent && this.Visible && --this.inRange == 0)
            {
                GameObject go = this.gameObject;
                Layers temp = (Layers)go.layer;
                go.layer = (int)this.switchLayer;
                this.switchLayer = temp;
                this.Visible = false;
            }
        }
        #endregion
    }
}
