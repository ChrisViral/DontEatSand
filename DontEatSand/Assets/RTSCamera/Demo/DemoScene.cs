using UnityEngine;
using UnityEngine.UI;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    public class DemoScene : MonoBehaviour
    {
        #region Fields
        public Button btn45;
        public Button btn90;
        #endregion

        #region Static methods
        private static void SetXRotation(Transform t, float angle)
        {
            Vector3 euler = t.localEulerAngles;
            t.localEulerAngles = new Vector3(angle, euler.y, euler.z);
        }
        #endregion

        #region Functions
        private void Start()
        {
            if (Camera.main != null)
            {
                Transform camT = Camera.main.transform;
                this.btn45.onClick.AddListener(() => SetXRotation(camT, 45f));
                this.btn90.onClick.AddListener(() => SetXRotation(camT, 90f));
            }
        }
        #endregion
    }
}
