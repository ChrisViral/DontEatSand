using System.IO;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// General utility static class
    /// </summary>
    public static class DESUtils
    {
        #region Constants
        /// <summary>
        /// Location of the Unit Database file
        /// </summary>
        public static string DatabaseLocation { get; } = Path.Combine(Application.dataPath, "unitdatabase.json");

        /// <summary>
        /// Location of the Unit BehaviourTree file
        /// </summary>
        public static string BehaviourTreeLocation { get; } = Path.Combine(Application.dataPath, "unit-behaviour.xml");
        #endregion

        #region Static methods
        /// <summary>
        /// Clamps a given Vector2 between a set of minimum and maximum values
        /// </summary>
        /// <param name="v">Vector to clamp</param>
        /// <param name="min">Minimum components vector</param>
        /// <param name="max">Maximum components vector</param>
        /// <returns>A new Vector2, correctly clamped</returns>
        public static Vector2 ClampVector2(Vector2 v, Vector2 min, Vector2 max) => new Vector2(Mathf.Clamp(v.x, min.x, max.x), Mathf.Clamp(v.y, min.y, max.y));

        /// <summary>
        /// Transforms an 'ALL_CAPS' or 'all_lower' string to a CamelCase string
        /// </summary>
        /// <param name="s">String to transform</param>
        /// <returns>The CamelCase version of the string</returns>
        public static string ToCamelCase(string s)
        {
            //Setup char buffer
            bool upper = true;
            char[] buffer = s.ToCharArray();
            int index = 0;

            //Loop through reference string
            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                //Add characters correctly
                if (c == '_') { upper = true; }
                else
                {
                    buffer[index++] = upper ? char.ToUpper(c) : char.ToLower(c);
                    upper = false;
                }
            }

            //Return the final string
            return new string(buffer, 0, index);
        }
        #endregion
    }
}
