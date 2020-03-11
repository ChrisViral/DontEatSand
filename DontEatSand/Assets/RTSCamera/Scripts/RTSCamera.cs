using System;
using UnityEngine;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    [RequireComponent(typeof(Camera)), AddComponentMenu("RTS Camera")]
    public class RTSCamera : MonoBehaviour
    {

#if UNITY_EDITOR
        #region Editor GUI Fields
        public int lastTab;
        public bool movementFoldout;
        public bool zoomingFoldout;
        public bool rotationFoldout;
        public bool heightFoldout;
        public bool mapLimitFoldout;
        public bool targetingFoldout;
        public bool inputFoldout;
        #endregion
#endif

        #region Static properties
        private static Vector2 MouseInput => Input.mousePosition;

        private static Vector2 MouseAxis => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        #endregion

        #region Fields
        //Movement
        public bool useFixedUpdate; //Use FixedUpdate() or Update()
        public float keyboardMovementSpeed = 5f; //Speed with keyboard movement
        public float screenEdgeMovementSpeed = 3f; //Speed with screen edge movement
        public float followingSpeed = 5f; //Speed when following a target
        public float rotationSped = 3f;
        public float panningSpeed = 10f;
        public float mouseRotationSpeed = 10f;

        //Height
        public bool autoHeight = true;
        public LayerMask groundMask = -1; //Layermask of ground or other objects that affect height
        public float maxHeight = 10f; //Maximal height
        public float minHeight = 15f; //Minimal height
        public float heightDampening = 5f;
        public float keyboardZoomingSensitivity = 2f;
        public float scrollWheelZoomingSensitivity = 25f;
        private float zoomPos; //Value in range (0, 1) used as t in Mathf.Lerp

        //Map limits
        public bool limitMap = true;
        public float limitX = 50f; //X limit of map
        public float limitY = 50f; //Z limit of map

        //Targeting
        public Transform targetFollow; //Target to follow
        public Vector3 targetOffset;

        //Input
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
        #endregion

        #region Properties
        /// <summary>
        /// If we are following a target
        /// </summary>
        public bool FollowingTarget => this.targetFollow != null;

        private Vector2 KeyboardInput => this.useKeyboardInput ? new Vector2(Input.GetAxis(this.horizontalAxis), Input.GetAxis(this.verticalAxis)) : Vector2.zero;

        private float ScrollWheel => Input.GetAxis(this.zoomingAxis);

        private int ZoomDirection
        {
            get
            {
                bool zoomIn = Input.GetKey(this.zoomInKey);
                bool zoomOut = Input.GetKey(this.zoomOutKey);
                if (zoomOut)
                {
                    if (!zoomIn)
                    {
                        //Zooming out
                        return -1;
                    }
                }
                else if (zoomIn)
                {
                    //Zooming in
                    return 1;
                }

                //Doing both/none
                return 0;
            }
        }

        private int RotationDirection
        {
            get
            {
                bool right = Input.GetKey(this.rotateRightKey);
                bool left = Input.GetKey(this.rotateLeftKey);
                if (left)
                {
                    if (!right)
                    {
                        return -1;
                    }
                }
                else if (right)
                {
                    return 1;
                }

                return 0;
            }
        }

        /// <summary>
        /// Vertical distance from the camera to the ground
        /// </summary>
        private float DistanceToGround
        {
            get
            {
                Vector3 pos = this.transform.position;
                return Physics.Raycast(pos, Vector3.down, out RaycastHit hit, this.groundMask.value) ? hit.distance : 0f;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update camera movement and rotation
        /// </summary>
        private void CameraUpdate()
        {
            if (this.FollowingTarget) { FollowTarget(); }
            else { Move(); }

            HeightCalculation();
            Rotation();
            LimitPosition();
        }

        /// <summary>
        /// Move camera with keyboard or with screen edge
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
        /// Calculate height
        /// </summary>
        private void HeightCalculation()
        {
            float distanceToGround = this.DistanceToGround;
            if(this.useScrollwheelZooming) this.zoomPos += this.ScrollWheel * Time.deltaTime * this.scrollWheelZoomingSensitivity;
            if (this.useKeyboardZooming) this.zoomPos += this.ZoomDirection * Time.deltaTime * this.keyboardZoomingSensitivity;

            this.zoomPos = Mathf.Clamp01(this.zoomPos);

            float targetHeight = Mathf.Lerp(this.minHeight, this.maxHeight, this.zoomPos);
            float difference = 0;

            if(Math.Abs(distanceToGround - targetHeight) > 0.001f)
            {
                difference = targetHeight - distanceToGround;
            }

            Vector3 pos = this.transform.position;
            this.transform.position = Vector3.Lerp(pos, new Vector3(pos.x, targetHeight + difference, pos.z), Time.deltaTime * this.heightDampening);
        }

        /// <summary>
        /// Rotate camera
        /// </summary>
        private void Rotation()
        {
            if (this.useKeyboardRotation)
            {
                this.transform.Rotate(Vector3.up, this.RotationDirection * Time.deltaTime * this.rotationSped, Space.World);
            }

            if (this.useMouseRotation && Input.GetKey(this.mouseRotationKey))
            {
                this.transform.Rotate(Vector3.up, -MouseAxis.x * Time.deltaTime * this.mouseRotationSpeed, Space.World);
            }
        }

        /// <summary>
        /// Follow target if target != null
        /// </summary>
        private void FollowTarget()
        {
            Vector3 pos = this.transform.position, targetPos = this.targetFollow.position;
            this.transform.position = Vector3.MoveTowards(pos, new Vector3(targetPos.x, pos.y, targetPos.z) + this.targetOffset, Time.deltaTime * this.followingSpeed);
        }

        /// <summary>
        /// Limit camera position
        /// </summary>
        private void LimitPosition()
        {
            if (!this.limitMap) { return; }

            Vector3 pos = this.transform.position;
            this.transform.position = new Vector3(Mathf.Clamp(pos.x, -this.limitX, this.limitX), pos.y, Mathf.Clamp(pos.z, -this.limitY, this.limitY));
        }

        /// <summary>
        /// Set the target
        /// </summary>
        /// <param name="target">New target to follow</param>
        public void SetTarget(Transform target) => this.targetFollow = target;

        /// <summary>
        /// Reset the target to null
        /// </summary>
        public void ResetTarget() => this.targetFollow = null;
        #endregion

        #region Functions
        private void Update()
        {
            if (!this.useFixedUpdate)
            {
                CameraUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (this.useFixedUpdate)
            {
                CameraUpdate();
            }
        }
        #endregion
    }
}