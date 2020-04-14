using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DontEatSand.UI
{
    public class FaceCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;

        private void Update()
        {
            transform.LookAt(camera.transform, camera.transform.up);
        }
    }
}

