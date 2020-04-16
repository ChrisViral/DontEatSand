using System;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// A generic Stopwatch clone running on Unity's internal clock
    /// </summary>
    public class Timer
    {
        #region Constants
        /// <summary>
        /// The amount of ticks in a second
        /// </summary>
        protected const long TICKS_PER_SECOND = 10000000L;

        /// <summary>
        /// The amount of milliseconds in a second
        /// </summary>
        protected const long MILLISECOND_PER_SECOND = 1000L;
        #endregion

        #region Fields
        /// <summary>
        /// UT of the last frame
        /// </summary>
        protected float lastCheck;

        /// <summary>
        /// Total elapsed time calculated by the watch in seconds
        /// </summary>
        protected float totalSeconds;
        #endregion

        #region Propreties
        /// <summary>
        /// If the watch is currently counting down time
        /// </summary>
        public bool IsRunning { get; protected set; }

        /// <summary>
        /// The current Time that the clock is based off
        /// </summary>
        protected virtual float CurrentTime => Time.time;

        /// <summary>
        /// The current elapsed time of the watch
        /// </summary>
        public TimeSpan Elapsed => new TimeSpan(this.ElapsedTicks);

        /// <summary>
        /// The total time in seconds elapsed to the current watch
        /// </summary>
        public float ElapsedSeconds
        {
            get
            {
                if (this.IsRunning) { UpdateWatch(); }
                return this.totalSeconds;
            }
        }

        /// <summary>
        /// The amount of milliseconds elapsed to the current watch
        /// </summary>
        public long ElapsedMilliseconds
        {
            get
            {
                if (this.IsRunning) { UpdateWatch(); }
                return (long)Math.Round(this.totalSeconds * MILLISECOND_PER_SECOND);
            }
        }

        /// <summary>
        /// The amount of ticks elapsed to the current watch
        /// </summary>
        public long ElapsedTicks
        {
            get
            {
                if (this.IsRunning) { UpdateWatch(); }
                return (long)(this.totalSeconds * TICKS_PER_SECOND);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Timer
        /// </summary>
        public Timer() { }

        /// <summary>
        /// Creates a new Timer starting at a certain amount of time
        /// </summary>
        /// <param name="seconds">Time to start at, in seconds</param>
        public Timer(float seconds) => this.totalSeconds = seconds;
        #endregion

        #region Static Methods
        /// <summary>
        /// Creates a new Timer, starts it, and returns the current instance
        /// </summary>
        public static Timer StartNew()
        {
            Timer timer = new Timer();
            timer.Start();
            return timer;
        }

        /// <summary>
        /// Creates a new Timer from a certain amount of time, starts it, and returns the current instance
        /// </summary>
        /// <param name="seconds">Time to start the watch at, in seconds</param>
        public static Timer StartNewFromTime(float seconds)
        {
            Timer timer = new Timer(seconds);
            timer.Start();
            return timer;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the watch
        /// </summary>
        public void Start()
        {
            if (!this.IsRunning)
            {
                this.lastCheck = this.CurrentTime;
                this.IsRunning = true;
            }
        }

        /// <summary>
        /// Stops the watch
        /// </summary>
        public void Stop()
        {
            if (this.IsRunning)
            {
                UpdateWatch();
                this.IsRunning = false;
            }
        }

        /// <summary>
        /// Resets the watch to zero and starts it
        /// </summary>
        public void Restart()
        {
            this.totalSeconds = 0f;
            this.lastCheck = this.CurrentTime;
            this.IsRunning = true;
        }

        /// <summary>
        /// Stops the watch and resets it to zero
        /// </summary>
        public void Reset()
        {
            this.totalSeconds = 0f;
            this.lastCheck = 0f;
            this.IsRunning = false;
        }

        /// <summary>
        /// Updates the time on the watch
        /// </summary>
        protected virtual void UpdateWatch()
        {
            float current = this.CurrentTime;
            this.totalSeconds += current - this.lastCheck;
            this.lastCheck = current;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns a string representation fo this instance
        /// </summary>
        public override string ToString() => this.Elapsed.ToString();
        #endregion
    }
}