using UnityEngine;

// ReSharper disable once CheckNamespace
namespace RTSCam
{
    [RequireComponent(typeof(RTSCamera))]
    public class TargetSelector : MonoBehaviour
    {
        #region Fields
        private RTSCamera rtsCam;
        private new Camera camera;
        [SerializeField]
        private string targetsTag;
        #endregion

        #region Functions
        private void Awake()
        {
            this.rtsCam = GetComponent<RTSCamera>();
            this.camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(this.camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.transform.CompareTag(this.targetsTag))
                    {
                        this.rtsCam.SetTarget(hit.transform);
                    }
                    else
                    {
                        this.rtsCam.ResetTarget();
                    }
                }
            }
        }
        #endregion
    }
}
