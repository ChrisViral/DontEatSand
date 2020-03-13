using UnityEngine;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    [RequireComponent(typeof(Camera)), AddComponentMenu("RTS Camera")]
    public class RTSCamera : MonoBehaviour
    {
        #region Constants
        /// <summary>
        /// Minimum detected movement
        /// </summary>
        private const float EPSILON = 0.001f;
        private const float MIN_TILT = 20f;
        private const float MAX_TILT = 75f;
        #endregion

        #region Editor GUI Fields
#if UNITY_EDITOR
        public int lastTab;
        public bool movementFoldout;
        public bool zoomingFoldout;
        public bool rotationFoldout;
        public bool heightFoldout;
        public bool mapLimitFoldout;
        public bool targetingFoldout;
        public bool inputFoldout;
#endif
        #endregion

        #region Static properties
        /// <summary>
        /// Mouse Position Vector
        /// </summary>
        private static Vector2 MouseInput => Input.mousePosition;

        /// <summary>
        /// Mouse movement vector
        /// </summary>
        private static Vector2 MouseAxis => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        #endregion

        #region Fields
        //Camera
        private new Camera camera;
        private float distance;

        //Movement
        public float keyboardMovementSpeed = 5f; //Speed with keyboard movement
        public float screenEdgeMovementSpeed = 3f; //Speed with screen edge movement
        public float followingSpeed = 5f; //Speed when following a target
        public float rotationSped = 3f;
        public float panningSpeed = 10f;
        public float mouseRotationSpeed = 10f;

        //Height
        public bool autoHeight = true;
        public LayerMask groundMask = -1; //Layermask of ground or other objects that affect height
        public float maxOrtho = 2f; //Maximal height
        public float minOrtho = 10f; //Minimal height
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
        #endregion

        #region Methods
        /// <summary>
        /// Move camera with keyboard or with screen edge
        /// </summary>
        private void Move()
        {
            //For translation movement, we want to move the parent
            Transform parent = this.transform.parent;
            if (this.useKeyboardInput)
            {
                Vector3 desiredMove = new Vector3(this.KeyboardInput.x, 0, this.KeyboardInput.y);

                desiredMove *= this.keyboardMovementSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, parent.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = parent.InverseTransformDirection(desiredMove);

                parent.Translate(desiredMove, Space.Self);
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
                desiredMove = Quaternion.Euler(new Vector3(0f, parent.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = parent.InverseTransformDirection(desiredMove);

                parent.Translate(desiredMove, Space.Self);
            }

            if(this.usePanning && Input.GetKey(this.panningKey) && MouseAxis.magnitude >= EPSILON)
            {
                Vector3 desiredMove = new Vector3(-MouseAxis.x, 0, -MouseAxis.y);

                desiredMove *= this.panningSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, parent.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = parent.InverseTransformDirection(desiredMove);

                parent.Translate(desiredMove, Space.Self);
            }
        }

        /// <summary>
        /// Calculate height
        /// </summary>
        private void HeightCalculation()
        {
            if(this.useScrollwheelZooming) this.zoomPos += this.ScrollWheel * Time.deltaTime * this.scrollWheelZoomingSensitivity;
            if (this.useKeyboardZooming) this.zoomPos += this.ZoomDirection * Time.deltaTime * this.keyboardZoomingSensitivity;

            this.zoomPos = Mathf.Clamp01(this.zoomPos);
            this.camera.orthographicSize = Mathf.Lerp(this.minOrtho, this.maxOrtho, this.zoomPos);

            Vector3 pos = this.transform.parent.position;
            if (Physics.Raycast(pos, Vector3.up, out RaycastHit hit, 20f, this.groundMask))
            {
                this.transform.parent.position = Vector3.Lerp(pos, new Vector3(pos.x, hit.point.y - 1f, pos.z), Time.deltaTime * this.heightDampening);
            }
        }

        /// <summary>
        /// Rotate camera
        /// </summary>
        private void Rotation()
        {
            Transform parent = this.transform.parent;
            if (this.useKeyboardRotation)
            {
                parent.Rotate(Vector3.up, this.RotationDirection * Time.deltaTime * this.rotationSped, Space.World);
            }

            if (this.useMouseRotation && Input.GetKey(this.mouseRotationKey))
            {
                //Panning rotation
                Vector2 mouse = MouseAxis;
                parent.Rotate(Vector3.up, -mouse.x * Time.deltaTime * this.mouseRotationSpeed, Space.World);

                //Tilting rotation
                Transform t = this.transform;
                float tiltAngle = t.eulerAngles.x;
                float newTilt = Mathf.Clamp(tiltAngle - (mouse.y * Time.deltaTime * this.mouseRotationSpeed), MIN_TILT, MAX_TILT);
                t.Rotate(Vector2.right, newTilt - tiltAngle, Space.Self);
                newTilt *= Mathf.Deg2Rad;
                this.transform.localPosition = new Vector3(0f, Mathf.Sin(newTilt) * this.distance, -Mathf.Cos(newTilt) * this.distance);
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

            Transform parent = this.transform.parent;
            Vector3 pos = parent.position;
            parent.position = new Vector3(Mathf.Clamp(pos.x, -this.limitX, this.limitX), pos.y, Mathf.Clamp(pos.z, -this.limitY, this.limitY));
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
        private void Awake() => this.camera = GetComponent<Camera>();

        private void Start()
        {
            Transform t = this.transform;
            float tiltAngle = Mathf.Clamp(t.eulerAngles.x, MIN_TILT, MAX_TILT) * Mathf.Deg2Rad;
            this.distance = t.localPosition.magnitude;
            this.transform.position = new Vector3(0f, Mathf.Sin(tiltAngle) * this.distance, -Mathf.Cos(tiltAngle) * this.distance);
            this.zoomPos = Mathf.InverseLerp(this.minOrtho, this.maxOrtho, this.camera.orthographicSize);
        }

        private void Update()
        {
            if (this.FollowingTarget) { FollowTarget(); }
            else { Move(); }

            HeightCalculation();
            Rotation();
            LimitPosition();
        }
        #endregion
    }
}