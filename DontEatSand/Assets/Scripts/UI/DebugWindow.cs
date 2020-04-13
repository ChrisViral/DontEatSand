using System.Collections.Generic;
using DontEatSand.Base;
using DontEatSand.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI
{
    [RequireComponent(typeof(Canvas))]
    public class DebugWindow : Singleton<DebugWindow>
    {
        /// <summary>
        /// A Queue implementation, forcing a fixed capacity, and dequeuing the latest member when it reaches capacity
        /// </summary>
        /// <typeparam name="T">Type of object stored in the Queue</typeparam>
        internal sealed class LogQueue<T> : Queue<T>
        {
            #region Constants
            /// <summary>
            /// Default capacity of the queue
            /// </summary>
            private const int defaultCapacity = 10;
            #endregion

            #region Properties
            /// <summary>
            /// Capacity of the queue (read-only)
            /// </summary>
            public int Capacity { get; }

            /// <summary>
            /// If there is room for more members in the queue
            /// </summary>
            public bool HasRoom => this.Count < this.Capacity;
            #endregion

            #region Constructors
            /// <summary>
            /// Creates a new LogQueue with the default capacity
            /// </summary>
            public LogQueue() : this(defaultCapacity) { }

            /// <summary>
            /// Creates a new LogQueue of the given capacity
            /// </summary>
            /// <param name="capacity">Capacity of the queue</param>
            public LogQueue(int capacity) : base(capacity) => this.Capacity = capacity;
            #endregion

            #region Methods
            /// <summary>
            /// Logs an item to the queue (and automatically dequeues if the queue is full)
            /// </summary>
            /// <param name="item">Item to log</param>
            /// <returns>The automatically dequeued item, if any, else the default value of <typeparamref name="T"/></returns>
            public T Log(T item)
            {
                T removed = this.HasRoom ? default : Dequeue();
                base.Enqueue(item);
                return removed;
            }

            /// <summary>
            /// Logs an item to the queue only if there is enough capacity for it
            /// </summary>
            /// <param name="item">Item to log</param>
            public new void Enqueue(T item)
            {
                if (this.HasRoom)
                {
                    base.Enqueue(item);
                }
            }
            #endregion
        }

        /// <summary>
        /// Temporary log data structure
        /// </summary>
        private readonly struct TempLog
        {
            #region Fields
            public string Message { get; }
            public string StackTrace { get; }
            public LogType Type { get; }
            #endregion

            #region Constructors
            /// <summary>
            /// Sets a new TempLog structure
            /// </summary>
            /// <param name="message">Log message</param>
            /// <param name="stackTrace">Log stack trace</param>
            /// <param name="type">Log type</param>
            public TempLog(string message, string stackTrace, LogType type)
            {
                this.Message = message;
                this.StackTrace = stackTrace;
                this.Type = type;
            }
            #endregion
        }

        #region Constants
        //Max amount of saved log messages
        private const int maxLogs = 500;
        //LogType -> Color conversion dictionary
        private static readonly Dictionary<LogType, Color> colours = new Dictionary<LogType, Color>(5)
        {
            [LogType.Log]       = XKCDColours.White,
            [LogType.Warning]   = XKCDColours.Yellow,
            [LogType.Assert]    = XKCDColours.Green,
            [LogType.Error]     = XKCDColours.Orange,
            [LogType.Exception] = XKCDColours.Red
        };
        #endregion

        #region Fields
        //Inspector fields
        [SerializeField]
        private Text version;
        [SerializeField]
        private GameObject window;
        [SerializeField]
        private ExpandableText logPrefab;
        [SerializeField]
        private Transform layout;

        //Private fields
        private List<TempLog> preLogs = new List<TempLog>();
        private readonly LogQueue<GameObject> queue = new LogQueue<GameObject>(maxLogs);
        #endregion

        #region Properties
        /// <summary>
        /// Debug window visibility
        /// </summary>
        public bool Visible
        {
            get => this.window.activeSelf;
            set => this.window.SetActive(value);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Prints logged messages to the debug window
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="stackTrace">Log stack trace</param>
        /// <param name="type">Log type</param>
        private void OnLog(string message, string stackTrace, LogType type)
        {
            message = message.Trim();
            if (string.IsNullOrEmpty(message)) { return; }

            ExpandableText log = Instantiate(this.logPrefab, this.layout, true);
            log.SetText(message, message + (type == LogType.Exception ? "\n" + stackTrace : string.Empty), colours[type]);
            GameObject removed = this.queue.Log(log.gameObject);
            if (removed != null)
            {
                Destroy(removed);
            }
        }

        /// <summary>
        /// Saves log messages to a list for future display
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="stackTrace">Log stack trace</param>
        /// <param name="type">Log type</param>
        private void OnLogDelayed(string message, string stackTrace, LogType type) => this.preLogs.Add(new TempLog(message, stackTrace, type));
        #endregion

        #region Functions
        protected override void OnAwake()
        {
            //Messages cannot be displayed correctly until Start()
            Application.logMessageReceived += OnLogDelayed;
            this.version.text += GameVersion.VersionString;
        }

        private void Start()
        {
            //Change log callback
            Application.logMessageReceived -= OnLogDelayed;
            Application.logMessageReceived += OnLog;

            //Log everything that was missed
            foreach (TempLog temp in this.preLogs)
            {
                OnLog(temp.Message, temp.StackTrace, temp.Type);
            }

            //We don't need this reference anymore
            this.preLogs = null;
        }

        private void Update()
        {
            //Set visibility
            if (Input.GetKey(KeyCode.AltGr) && Input.GetKeyDown(KeyCode.F11))
            {
                this.Visible = !this.Visible;
            }
        }

        //Remove event
        private void OnDestroy() => Application.logMessageReceived -= OnLog;
        #endregion
    }
}
