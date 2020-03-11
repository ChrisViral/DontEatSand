using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// Game specific input handling class
    /// </summary>
    public static class InputUtils
    {
        #region Constants
        /// <summary>
        /// Horizontal axis name
        /// </summary>
        public const string HORIZONTAL = "Horizontal";
        /// <summary>
        /// Vertical axis name
        /// </summary>
        public const string VERTICAL = "Vertical";
        /// <summary>
        /// Pause button name
        /// </summary>
        public const string PAUSE = "Pause";
        #endregion

        #region Static properties
        /// <summary>
        /// Horizontal axis value
        /// </summary>
        public static float Horizontal => Input.GetAxis(HORIZONTAL);

        /// <summary>
        /// Vertical axis value
        /// </summary>
        public static float Vertical => Input.GetAxis(VERTICAL);

        /// <summary>
        /// Pause pressed
        /// </summary>
        public static bool Pause => Input.GetButtonDown(PAUSE);
        #endregion
    }
}
