using DontEatSand.Utils;
using Photon.Pun;
using UnityEngine;

namespace DontEatSand.Base
{
    [DisallowMultipleComponent, RequireComponent(typeof(Collider))]
    public class Discoverable : MonoBehaviourPun
    {
        #region Fields
        [SerializeField, Tooltip("The layer to switch to")]
        private Layers invisibleLayer = Layers.DEFAULT;
        [SerializeField, Tooltip("If the discovery is permanent or not")]
        private bool permanent;
        private Layer otherLayer;
        private int inRange;
        #endregion

        #region Properties
        private bool visible = true;
        /// <summary>
        /// If the object is currently visible or not
        /// </summary>
        public bool Visible
        {
            get => this.visible;
            set
            {
                if (this.visible != value)
                {
                    GameObject go = this.gameObject;
                    Layer temp = LayerUtils.GetLayer(go.layer);
                    go.ChangeLayerRecursively(this.otherLayer);
                    this.otherLayer = temp;
                    this.visible = value;
                }
            }
        }
        #endregion

        #region Functions
        private void Start()
        {
            this.otherLayer = LayerUtils.GetLayer(this.invisibleLayer);
            this.Visible = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            this.Log(other.name);
            if (this.permanent)
            {
                //If invisible, make visible
                if (!this.Visible)
                {
                    this.gameObject.layer = this.otherLayer.Value;
                    this.visible = true;
                }
            }
            else
            {
                //If invisible, make visible, and increment counter
                this.inRange++;
                if (!this.Visible)
                {
                    this.Visible = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //If visible and counter reaches zero, make invisible
            if (!this.permanent && this.Visible && --this.inRange == 0)
            {
                this.Visible = false;
            }
        }
        #endregion
    }
}
