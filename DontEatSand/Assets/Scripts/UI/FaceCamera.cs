using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTSCam;

namespace DontEatSand.UI
{
    public class FaceCamera : MonoBehaviour
    {
        private new RTSCamera camera;

        private void Awake()
        {
            this.camera = Camera.main.GetComponent<RTSCamera>();
        }

        private void Update()
        {
            transform.LookAt(camera.transform, camera.transform.up);
        }
    }
}

