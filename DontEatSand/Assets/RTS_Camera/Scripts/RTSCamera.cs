using System;
using UnityEngine;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    [RequireComponent(typeof(Camera)), AddComponentMenu("RTS Camera")]
    public class RTSCamera : MonoBehaviour
    {

        #region Foldouts
#if UNITY_EDITOR
        public int lastTab;
        public bool movementSettingsFoldout;
        public bool zoomingSettingsFoldout;
        public bool rotationSettingsFoldout;
        public bool heightSettingsFoldout;
        public bool mapLimitSettingsFoldout;
        public bool targetingSettingsFoldout;
        public bool inputSettingsFoldout;
#endif
        #endregion

        public bool useFixedUpdate; //use FixedUpdate() or Update()

        #region Movement
        public float keyboardMovementSpeed = 5f; //speed with keyboard movement
        public float screenEdgeMovementSpeed = 3f; //speed with screen edge movement
        public float followingSpeed = 5f; //speed when following a target
        public float rotationSped = 3f;
        public float panningSpeed = 10f;
        public float mouseRotationSpeed = 10f;
        #endregion

        #region Height
        public bool autoHeight = true;
        public LayerMask groundMask = -1; //layermask of ground or other objects that affect height

        public float maxHeight = 10f; //maximal height
        public float minHeight = 15f; //minimal height
        public float heightDampening = 5f;
        public float keyboardZoomingSensitivity = 2f;
        public float scrollWheelZoomingSensitivity = 25f;

        private float zoomPos; //value in range (0, 1) used as t in Mathf.Lerp
        #endregion

        #region MapLimits
        public bool limitMap = true;
        public float limitX = 50f; //x limit of map
        public float limitY = 50f; //z limit of map
        #endregion

        #region Targeting
        public Transform targetFollow; //target to follow
        public Vector3 targetOffset;

        /// <summary>
        /// are we following target
        /// </summary>
        public bool FollowingTarget => this.targetFollow != null;
        #endregion

        #region Input
        public bool useScreenEdgeInput = true;
        public float screenEdgeBorder = 25f;

        public bool useKeyboardInput = true;
        public string horizontalAxis = "Horizontal";
        public string verticalAxis = "Vertical";

        public bool usePanning = true;
        public KeyCode panningKey = KeyCode.Mouse2;

        public bool useKeyboardZooming = true;
        public KeyCode zoomInKey = KeyCode.E;
        public KeyCode zoomOutKey = KeyCode.Q;

        public bool useScrollwheelZooming = true;
        public string zoomingAxis = "Mouse ScrollWheel";

        public bool useKeyboardRotation = true;
        public KeyCode rotateRightKey = KeyCode.X;
        public KeyCode rotateLeftKey = KeyCode.Z;

        public bool useMouseRotation = true;
        public KeyCode mouseRotationKey = KeyCode.Mouse1;

        private Vector2 KeyboardInput => this.useKeyboardInput ? new Vector2(Input.GetAxis(this.horizontalAxis), Input.GetAxis(this.verticalAxis)) : Vector2.zero;

        private static Vector2 MouseInput => Input.mousePosition;

        private float ScrollWheel => Input.GetAxis(this.zoomingAxis);

        private static Vector2 MouseAxis => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        private int ZoomDirection
        {
            get
            {
                bool zoomIn = Input.GetKey(this.zoomInKey);
                bool zoomOut = Input.GetKey(this.zoomOutKey);
                if (zoomIn && zoomOut)
                    return 0;
                if (!zoomIn && zoomOut)
                    return 1;
                if (zoomIn)
                    return -1;

                return 0;
            }
        }

        private int RotationDirection
        {
            get
            {
                bool rotateRight = Input.GetKey(this.rotateRightKey);
                bool rotateLeft = Input.GetKey(this.rotateLeftKey);
                if(rotateLeft && rotateRight)
                    return 0;
                if(rotateLeft)
                    return -1;
                return rotateRight ? 1 : 0;
            }
        }

        #endregion

        #region Unity_Methods
        private void Update()
        {
            if (!this.useFixedUpdate)
                CameraUpdate();
        }

        private void FixedUpdate()
        {
            if (this.useFixedUpdate)
                CameraUpdate();
        }
        #endregion

        #region RTSCamera_Methods
        /// <summary>
        /// update camera movement and rotation
        /// </summary>
        private void CameraUpdate()
        {
            if (this.FollowingTarget)
                FollowTarget();
            else
                Move();

            HeightCalculation();
            Rotation();
            LimitPosition();
        }

        /// <summary>
        /// move camera with keyboard or with screen edge
        /// </summary>
        private void Move()
        {
            if (this.useKeyboardInput)
            {
                Vector3 desiredMove = new Vector3(this.KeyboardInput.x, 0, this.KeyboardInput.y);

                desiredMove *= this.keyboardMovementSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, this.transform.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = this.transform.InverseTransformDirection(desiredMove);

                this.transform.Translate(desiredMove, Space.Self);
            }

            if (this.useScreenEdgeInput)
            {
                Vector3 desiredMove = new Vector3();

                Rect leftRect = new Rect(0, 0, this.screenEdgeBorder, Screen.height);
                Rect rightRect = new Rect(Screen.width - this.screenEdgeBorder, 0, this.screenEdgeBorder, Screen.height);
                Rect upRect = new Rect(0, Screen.height - this.screenEdgeBorder, Screen.width, this.screenEdgeBorder);
                Rect downRect = new Rect(0, 0, Screen.width, this.screenEdgeBorder);

                desiredMove.x = leftRect.Contains(MouseInput) ? -1 : rightRect.Contains(MouseInput) ? 1 : 0;
                desiredMove.z = upRect.Contains(MouseInput) ? 1 : downRect.Contains(MouseInput) ? -1 : 0;

                desiredMove *= this.screenEdgeMovementSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, this.transform.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = this.transform.InverseTransformDirection(desiredMove);

                this.transform.Translate(desiredMove, Space.Self);
            }

            if(this.usePanning && Input.GetKey(this.panningKey) && MouseAxis != Vector2.zero)
            {
                Vector3 desiredMove = new Vector3(-MouseAxis.x, 0, -MouseAxis.y);

                desiredMove *= this.panningSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, this.transform.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = this.transform.InverseTransformDirection(desiredMove);

                this.transform.Translate(desiredMove, Space.Self);
            }
        }

        /// <summary>
        /// calculate height
        /// </summary>
        private void HeightCalculation()
        {
            float distanceToGround = DistanceToGround();
            if(this.useScrollwheelZooming) this.zoomPos += this.ScrollWheel * Time.deltaTime * this.scrollWheelZoomingSensitivity;
            if (this.useKeyboardZooming) this.zoomPos += this.ZoomDirection * Time.deltaTime * this.keyboardZoomingSensitivity;

            this.zoomPos = Mathf.Clamp01(this.zoomPos);

            float targetHeight = Mathf.Lerp(this.minHeight, this.maxHeight, this.zoomPos);
            float difference = 0;

            if(Math.Abs(distanceToGround - targetHeight) > 0.001f)
                difference = targetHeight - distanceToGround;

            this.transform.position = Vector3.Lerp(this.transform.position,
                                                   new Vector3(this.transform.position.x, targetHeight + difference, this.transform.position.z), Time.deltaTime * this.heightDampening);
        }

        /// <summary>
        /// rotate camera
        /// </summary>
        private void Rotation()
        {
            if(this.useKeyboardRotation) this.transform.Rotate(Vector3.up, this.RotationDirection * Time.deltaTime * this.rotationSped, Space.World);

            if (this.useMouseRotation && Input.GetKey(this.mouseRotationKey))
                this.transform.Rotate(Vector3.up, -MouseAxis.x * Time.deltaTime * this.mouseRotationSpeed, Space.World);
        }

        /// <summary>
        /// follow target if target != null
        /// </summary>
        private void FollowTarget()
        {
            Vector3 targetPos = new Vector3(this.targetFollow.position.x, this.transform.position.y, this.targetFollow.position.z) + this.targetOffset;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * this.followingSpeed);
        }

        /// <summary>
        /// limit camera position
        /// </summary>
        private void LimitPosition()
        {
            if (!this.limitMap)
                return;

            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -this.limitX, this.limitX),
                                                  this.transform.position.y,
                                                  Mathf.Clamp(this.transform.position.z, -this.limitY, this.limitY));
        }

        /// <summary>
        /// set the target
        /// </summary>
        /// <param name="target"></param>
        public void SetTarget(Transform target)
        {
            this.targetFollow = target;
        }

        /// <summary>
        /// reset the target (target is set to null)
        /// </summary>
        public void ResetTarget()
        {
            this.targetFollow = null;
        }

        /// <summary>
        /// calculate distance to ground
        /// </summary>
        /// <returns></returns>
        private float DistanceToGround()
        {
            Ray ray = new Ray(this.transform.position, Vector3.down);
            return Physics.Raycast(ray, out RaycastHit hit, this.groundMask.value) ? (hit.point - this.transform.position).magnitude : 0f;
        }

        #endregion
    }
}