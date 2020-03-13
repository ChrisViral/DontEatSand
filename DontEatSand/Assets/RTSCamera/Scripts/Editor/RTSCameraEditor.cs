using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    [CustomEditor(typeof(RTSCamera))]
    public class RTSCameraEditor : Editor
    {
        #region Properties
        /// <summary>
        /// The Camera object this editor targets
        /// </summary>
        private RTSCamera Camera => (RTSCamera)this.target;
        #endregion

        #region Fields
        private TabsBlock tabs;
        #endregion

        #region Methods
        public override void OnInspectorGUI()
        {
            Undo.RecordObject(this.Camera, "RTSCamera");
            this.tabs.Draw();
            if (GUI.changed) this.Camera.lastTab = this.tabs.curMethodIndex;
            if (this.serializedObject.hasModifiedProperties)
            {
                this.serializedObject.ApplyModifiedProperties();
            }
            EditorUtility.SetDirty(this.Camera);
        }

        private void MovementTab()
        {
            using (new HorizontalBlock())
            {
                GUILayout.Label("Use keyboard input: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useKeyboardInput = EditorGUILayout.Toggle(this.Camera.useKeyboardInput);
            }
            if(this.Camera.useKeyboardInput)
            {
                this.Camera.horizontalAxis = EditorGUILayout.TextField("Horizontal axis name: ", this.Camera.horizontalAxis);
                this.Camera.verticalAxis = EditorGUILayout.TextField("Vertical axis name: ", this.Camera.verticalAxis);
                this.Camera.keyboardMovementSpeed = EditorGUILayout.FloatField("Movement speed: ", this.Camera.keyboardMovementSpeed);
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Screen edge input: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useScreenEdgeInput = EditorGUILayout.Toggle(this.Camera.useScreenEdgeInput);
            }

            if(this.Camera.useScreenEdgeInput)
            {
                EditorGUILayout.FloatField("Edge border size: ", this.Camera.screenEdgeBorder);
                this.Camera.screenEdgeMovementSpeed = EditorGUILayout.FloatField("Edge movement speed: ", this.Camera.screenEdgeMovementSpeed);
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Panning with mouse: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.usePanning = EditorGUILayout.Toggle(this.Camera.usePanning);
            }
            if(this.Camera.usePanning)
            {
                this.Camera.panningKey = (KeyCode)EditorGUILayout.EnumPopup("Panning when holding: ", this.Camera.panningKey);
                this.Camera.panningSpeed = EditorGUILayout.FloatField("Panning speed: ", this.Camera.panningSpeed);
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Limit movement: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.limitMap = EditorGUILayout.Toggle(this.Camera.limitMap);
            }
            if (this.Camera.limitMap)
            {
                this.Camera.limitX = EditorGUILayout.FloatField("Limit X: ", this.Camera.limitX);
                this.Camera.limitY = EditorGUILayout.FloatField("Limit Y: ", this.Camera.limitY);
            }

            GUILayout.Label("Follow target", EditorStyles.boldLabel);
            this.Camera.targetFollow = EditorGUILayout.ObjectField("Target to follow: ", this.Camera.targetFollow, typeof(Transform), true) as Transform;
            this.Camera.targetOffset = EditorGUILayout.Vector3Field("Target offset: ", this.Camera.targetOffset);
            this.Camera.followingSpeed = EditorGUILayout.FloatField("Following speed: ", this.Camera.followingSpeed);
        }

        private void RotationTab()
        {
            using (new HorizontalBlock())
            {
                GUILayout.Label("Keyboard input: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useKeyboardRotation = EditorGUILayout.Toggle(this.Camera.useKeyboardRotation);
            }
            if(this.Camera.useKeyboardRotation)
            {
                this.Camera.rotateLeftKey = (KeyCode)EditorGUILayout.EnumPopup("Rotate left: ", this.Camera.rotateLeftKey);
                this.Camera.rotateRightKey = (KeyCode)EditorGUILayout.EnumPopup("Rotate right: ", this.Camera.rotateRightKey);
                this.Camera.rotationSped = EditorGUILayout.FloatField("Keyboard rotation speed", this.Camera.rotationSped);
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Mouse input: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useMouseRotation = EditorGUILayout.Toggle(this.Camera.useMouseRotation);
            }
            if(this.Camera.useMouseRotation)
            {
                this.Camera.mouseRotationKey = (KeyCode)EditorGUILayout.EnumPopup("Mouse rotation key: ", this.Camera.mouseRotationKey);
                this.Camera.mouseRotationSpeed = EditorGUILayout.FloatField("Mouse rotation speed: ", this.Camera.mouseRotationSpeed);
            }
        }

        private void HeightTab()
        {
            using (new HorizontalBlock())
            {
                GUILayout.Label("Auto height: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.autoHeight = EditorGUILayout.Toggle(this.Camera.autoHeight);
            }
            if (this.Camera.autoHeight)
            {
                this.Camera.heightDampening = EditorGUILayout.FloatField("Height dampening: ", this.Camera.heightDampening);
                EditorGUILayout.PropertyField(this.serializedObject.FindProperty("groundMask"));
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Keyboard zooming: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useKeyboardZooming = EditorGUILayout.Toggle(this.Camera.useKeyboardZooming);
            }
            if(this.Camera.useKeyboardZooming)
            {
                this.Camera.zoomInKey = (KeyCode)EditorGUILayout.EnumPopup("Zoom In: ", this.Camera.zoomInKey);
                this.Camera.zoomOutKey = (KeyCode)EditorGUILayout.EnumPopup("Zoom Out: ", this.Camera.zoomOutKey);
                this.Camera.keyboardZoomingSensitivity = EditorGUILayout.FloatField("Keyboard sensitivity: ", this.Camera.keyboardZoomingSensitivity);
            }

            using (new HorizontalBlock())
            {
                GUILayout.Label("Scrollwheel zooming: ", EditorStyles.boldLabel, GUILayout.Width(170f));
                this.Camera.useScrollwheelZooming = EditorGUILayout.Toggle(this.Camera.useScrollwheelZooming);
            }
            if (this.Camera.useScrollwheelZooming) this.Camera.scrollWheelZoomingSensitivity = EditorGUILayout.FloatField("Scrollwheel sensitivity: ", this.Camera.scrollWheelZoomingSensitivity);

            if (this.Camera.useScrollwheelZooming || this.Camera.useKeyboardZooming)
            {
                this.Camera.maxOrtho = EditorGUILayout.FloatField("Max ortho size: ", this.Camera.maxOrtho);
                this.Camera.minOrtho = EditorGUILayout.FloatField("Min ortho size: ", this.Camera.minOrtho);
            }
        }
        #endregion

        #region Functions
        private void OnEnable()
        {
            this.tabs = new TabsBlock(new Dictionary<string, Action>
            {
                ["Movement"] = MovementTab,
                ["Rotation"] = RotationTab,
                ["Height"]   = HeightTab
            });
            this.tabs.SetCurrentMethod(this.Camera.lastTab);
        }
        #endregion
    }
}