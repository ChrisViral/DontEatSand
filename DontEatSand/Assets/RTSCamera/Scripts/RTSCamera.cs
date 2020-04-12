using System.Collections.Generic;
using System.Linq;
using DontEatSand.Entities;
using DontEatSand.Entities.Units;
using DontEatSand.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//ReSharper disable once CheckNamespace
namespace RTSCam
{
    /// <summary>
    /// RTS camera component
    /// </summary>
    [DisallowMultipleComponent, RequireComponent(typeof(Camera)), AddComponentMenu("RTS Camera")]
    public class RTSCamera : MonoBehaviour
    {
        #region Constants
        /// <summary>
        /// Minimum detected movement
        /// </summary>
        private const float TOLERANCE = 0.001f;
        /// <summary>
        /// Minimum tilt angle of the camera
        /// </summary>
        private const float MIN_TILT = 30f;
        /// <summary>
        /// Maximum tilt angle of the camera
        /// </summary>
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
        private LayerMask clickMask;
        #endregion

        #region Properties
        [SerializeField]
        private Transform target;
        /// <summary>
        /// Target to follow
        /// </summary>
        public Transform Target
        {
            get => this.target;
            set => this.target = value;
        }

        /// <summary>
        /// If we are following a target
        /// </summary>
        public bool FollowingTarget => this.Target;

        /// <summary>
        /// Keyboard movement input
        /// </summary>
        private Vector2 KeyboardInput => this.useKeyboardInput ? new Vector2(Input.GetAxis(this.horizontalAxis), Input.GetAxis(this.verticalAxis)) : Vector2.zero;

        /// <summary>
        /// Scroll wheel input
        /// </summary>
        private float ScrollWheel => Input.GetAxis(this.zoomingAxis);

        /// <summary>
        /// Zoom direction
        /// </summary>
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

        /// <summary>
        /// Rotation direction
        /// </summary>
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
        /// Returns the Selectable object under the mouse cursor
        /// </summary>
        public ISelectable Selected
        {
            get
            {
                //Check if we hit anything
                if (Physics.Raycast(this.camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 200f, this.clickMask, QueryTriggerInteraction.Ignore))
                {
                    //If we did, check for a selectable in the parent or current object
                    return hit.transform.GetComponent<ISelectable>() ?? hit.transform.GetComponentInParent<ISelectable>();
                }
                return null;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Move the camera around the world
        /// </summary>
        /// <returns>If the camera has moved from user input at all</returns>
        private bool Move()
        {
            //For translation movement, we want to move the parent
            Transform parent = this.transform.parent;
            Vector3 originalPos = parent.position;
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

            if(this.usePanning && Input.GetKey(this.panningKey) && MouseAxis.magnitude >= TOLERANCE)
            {
                Vector3 desiredMove = new Vector3(-MouseAxis.x, 0, -MouseAxis.y);

                desiredMove *= this.panningSpeed;
                desiredMove *= Time.deltaTime;
                desiredMove = Quaternion.Euler(new Vector3(0f, parent.eulerAngles.y, 0f)) * desiredMove;
                desiredMove = parent.InverseTransformDirection(desiredMove);

                parent.Translate(desiredMove, Space.Self);
            }

            //Check if we've moved at all
            return Vector3.Distance(originalPos, parent.position) > TOLERANCE;
        }

        /// <summary>
        /// Height/zoom adjustments
        /// </summary>
        private void HeightCalculation()
        {
            if(this.useScrollwheelZooming) this.zoomPos += this.ScrollWheel * Time.deltaTime * this.scrollWheelZoomingSensitivity;
            if (this.useKeyboardZooming) this.zoomPos += this.ZoomDirection * Time.deltaTime * this.keyboardZoomingSensitivity;

            this.zoomPos = Mathf.Clamp01(this.zoomPos);
            this.camera.orthographicSize = Mathf.Lerp(this.minOrtho, this.maxOrtho, this.zoomPos);

            //Not sure we're gonna need this, disabling for now
            //Vector3 pos = this.transform.parent.position;
            //if (Physics.Raycast(pos, Vector3.up, out RaycastHit hit, 20f, this.groundMask))
            //{
            //    this.transform.parent.position = Vector3.Lerp(pos, new Vector3(pos.x, hit.point.y - 1f, pos.z), Time.deltaTime * this.heightDampening);
            //}
        }

        /// <summary>
        /// Rotation adjustments of the camera
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
        /// Target following
        /// </summary>
        private void FollowTarget()
        {
            Vector3 pos = this.transform.position, targetPos = this.Target.position;
            this.transform.position = Vector3.MoveTowards(pos, new Vector3(targetPos.x, pos.y, targetPos.z) + this.targetOffset, Time.deltaTime * this.followingSpeed);
        }

        /// <summary>
        /// Limits camera position to specified boundaries
        /// </summary>
        private void LimitPosition()
        {
            if (!this.limitMap) { return; }

            Transform parent = this.transform.parent;
            Vector3 pos = parent.position;
            parent.position = new Vector3(Mathf.Clamp(pos.x, -this.limitX, this.limitX), pos.y, Mathf.Clamp(pos.z, -this.limitY, this.limitY));
        }

        /// <summary>
        /// Enumerates all the units within a given rect
        /// </summary>
        /// <param name="rect">Rect to check</param>
        /// <param name="units">Units to check for</param>
        /// <returns>A sequence of all the units within the rect</returns>
        public IEnumerable<Unit> GetWithinRect(Rect rect, IEnumerable<Unit> units) => units.Where(unit => rect.Contains(this.camera.WorldToScreenPoint(unit.Position)));
        #endregion

        #region Functions
        private void Awake()
        {
            this.camera = GetComponent<Camera>();
            this.clickMask = LayerUtils.GetMask(Layers.DEFAULT, Layers.GROUND, Layers.VISIBLE_UNIT, Layers.VISIBLE_RESOURCE);
        }

        private void Start()
        {
            Transform t = this.transform;
            float tiltAngle = Mathf.Clamp(t.eulerAngles.x, MIN_TILT, MAX_TILT) * Mathf.Deg2Rad;
            this.distance = t.localPosition.magnitude;
            this.transform.position = new Vector3(0f, Mathf.Sin(tiltAngle) * this.distance, -Mathf.Cos(tiltAngle) * this.distance);
            this.zoomPos = Mathf.InverseLerp(this.minOrtho, this.maxOrtho, this.camera.orthographicSize);
        }

        private void LateUpdate()
        {
            //Don't move camera while interacting with UI
            if (EventSystem.current.IsPointerOverGameObject()) { return; }

            if (this.FollowingTarget) { FollowTarget(); }

            if (Move())
            {
                //If moved while following target, stop
                if (this.FollowingTarget)
                {
                    this.Target = null;
                }
            }
            else if (this.FollowingTarget)
            {
                //Follow target if needed
                FollowTarget();
            }

            //Do regular calculations
            HeightCalculation();
            Rotation();
            LimitPosition();
        }
        #endregion
    }
}