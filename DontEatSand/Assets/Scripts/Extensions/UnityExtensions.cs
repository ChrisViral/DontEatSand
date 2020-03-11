using System;
using DontEatSand.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

//ReSharper disable once CheckNamespace
namespace DontEatSand
{
    /// <summary>
    /// Unity objects extension methods
    /// </summary>
    public static class UnityExtensions
    {
        #region Logging extensions
        /// <summary>
        /// Logs an object message
        /// </summary>
        /// <param name="o">Object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void Log(this object o, object message) => Debug.Log($"[{o.GetType().Name}]: {message}");

        /// <summary>
        /// Logs a given warning message
        /// </summary>
        /// <param name="o">Object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void LogWarning(this object o, object message) => Debug.LogWarning($"[{o.GetType().Name}]: {message}");

        /// <summary>
        /// Logs a given error message
        /// </summary>
        /// <param name="o">Object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void LogError(this object o, object message) => Debug.LogError($"[{o.GetType().Name}]: {message}");

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="o">Object that is logging</param>
        /// <param name="e">Exception to log</param>
        public static void LogException(this object o, Exception e) => Debug.LogException(e);

        /// <summary>
        /// Logs an object message
        /// </summary>
        /// <param name="o">MonoBehaviour object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void Log(this Object o, object message) => Debug.Log($"[{o.GetType().Name}]: {message}", o);

        /// <summary>
        /// Logs a given warning message
        /// </summary>
        /// <param name="o">MonoBehaviour object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void LogWarning(this Object o, object message) => Debug.LogWarning($"[{o.GetType().Name}]: {message}", o);

        /// <summary>
        /// Logs a given error message
        /// </summary>
        /// <param name="o">MonoBehaviour object that is logging</param>
        /// <param name="message">Message to log</param>
        public static void LogError(this Object o, object message) => Debug.LogError($"[{o.GetType().Name}]: {message}", o);

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="o">MonoBehaviour object that is logging</param>
        /// <param name="e">Exception to log</param>
        public static void LogException(this Object o, Exception e) => Debug.LogException(e, o);
        #endregion

        #region Object extensions
        /// <summary>
        /// Tests if a raycast hit is on a given layer
        /// </summary>
        /// <param name="hit">RaycastHit to test</param>
        /// <param name="layer">Layer to check</param>
        /// <returns>If they raycast hit an object on the specified layer or not</returns>
        public static bool OnLayer(this RaycastHit2D hit, Layer layer) => hit.collider.gameObject.layer == layer.Value;

        /// <summary>
        /// Tries to get a component from the GameObject, and stores it in the out parameter
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        /// <param name="o">The object to get the component of</param>
        /// <param name="component">The resulting component</param>
        /// <returns>True if the component was found, false otherwise</returns>
        public static bool TryGetComponent<T>(this GameObject o, out T component) where T : Component
        {
            component = o.GetComponent<T>();
            return component;
        }

        /// <summary>
        /// Tries to get a component from the GameObject of a given component, and stores it in the out parameter
        /// </summary>
        /// <typeparam name="T">Type of component to find</typeparam>
        /// <param name="o">The component/object to get the component of</param>
        /// <param name="component">The resulting component</param>
        /// <returns>True if the component was found, false otherwise</returns>
        public static bool TryGetComponent<T>(this Component o, out T component) where T : Component
        {
            component = o.GetComponent<T>();
            return component;
        }
        #endregion
    }
}
