using UnityEngine;

namespace DontEatSand.UI.Game
{
    [RequireComponent(typeof(Canvas))]
    public class FaceCamera : MonoBehaviour
    {
        #region Fields
        private Canvas canvas;
        private new Transform camera;
        #endregion

        #region Functions
        private void Awake()
        {
            Camera cam = Camera.main;
            this.camera = cam.transform;
            GetComponent<Canvas>().worldCamera = cam;
        }

        private void Update() => this.transform.LookAt(this.camera, this.camera.up);
        #endregion
    }
}

