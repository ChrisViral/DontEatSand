﻿using System;
using System.Collections.Generic;
using System.Linq;
using DontEatSand.Utils;
using UnityEngine;

namespace DontEatSand.Entities.Buildings
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class FactoryTemplate : MonoBehaviour
    {
        #region Constants
        /// <summary>
        /// Emission colour property hash
        /// </summary>
        private static readonly int emissionColorProperty = Shader.PropertyToID("_EmissionColor");
        #endregion

        #region Fields
        [SerializeField]
        private Color defaultColor, invalidColour;
        [SerializeField]
        private Layers groundLayer;
        private LayerMask groundMask;
        private new BoxCollider collider;
        private new Camera camera;
        private Transform cameraTransform;
        private readonly List<Material> materials = new List<Material>(3);
        private readonly Vector3[] bottom = new Vector3[4];
        private int inCollider;
        public bool validPosition;
        #endregion

        #region Properties
        private bool valid;
        /// <summary>
        /// If this template is currently in a valid position
        /// </summary>
        public bool Valid
        {
            get => this.valid;
            set
            {
                if (this.valid != value)
                {
                    this.valid = value;
                    this.materials.ForEach(m => m.SetColor(emissionColorProperty, value ? this.defaultColor : this.invalidColour));
                }
            }
        }
        #endregion

        #region Functions
        private void Awake()
        {
            //Get collision data
            this.materials.AddRange(GetComponentsInChildren<Renderer>().Select(r => r.material));
            this.collider = GetComponent<BoxCollider>();
            this.camera = Camera.main;
            this.cameraTransform = this.camera.transform;
            this.groundMask = 1 << (int)this.groundLayer;

            //Collider data
            Vector3 center = this.collider.center;
            Vector3 extents = this.collider.size / 2f;
            float y = center.y - extents.y;
            //Get all four bottom points
            this.bottom[0] = new Vector3(center.x + extents.x, y, center.z + extents.x);
            this.bottom[1] = new Vector3(center.x + extents.x, y, center.z - extents.x);
            this.bottom[2] = new Vector3(center.x - extents.x, y, center.z + extents.x);
            this.bottom[3] = new Vector3(center.x - extents.x, y, center.z - extents.x);
        }

        private void Update()
        {
            //Align to face camera camera
            this.transform.rotation = Quaternion.Euler(0f, this.cameraTransform.eulerAngles.y + 180f, 0f);

            //Check if where mouse is positioned has
            if (Physics.Raycast(this.camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 300f, this.groundMask, QueryTriggerInteraction.Ignore) && Vector3.Angle(hit.normal, Vector3.up) < 1f)
            {
                this.transform.position = hit.point;
                this.validPosition = true;
            }
            else
            {
                this.transform.position = new Vector3(0f, -5f, 0f);
                this.validPosition = false;
            }
        }

        private void FixedUpdate()
        {
            //Check if anything is in the collider and there is ground under the structure
            this.Valid = this.inCollider == 0 &&
                         this.bottom.Select(this.transform.TransformPoint)
                             .All(p => Physics.Raycast(p, Vector3.down, 0.25f, this.groundMask, QueryTriggerInteraction.Ignore));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger) { this.inCollider++; }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.isTrigger) { this.inCollider--; }
        }
        #endregion
    }
}