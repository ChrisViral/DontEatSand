using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace RTSCam
{
    public class VerticalBlock : IDisposable
    {
        #region Constructors
        public VerticalBlock(params GUILayoutOption[] options) => GUILayout.BeginVertical(options);

        public VerticalBlock(GUIStyle style, params GUILayoutOption[] options) => GUILayout.BeginVertical(style, options);
        #endregion

        #region Methods
        public void Dispose() => GUILayout.EndVertical();
        #endregion
    }

    public class ScrollviewBlock : IDisposable
    {
        #region Constructors
        public ScrollviewBlock(ref Vector2 scrollPos, params GUILayoutOption[] options) => scrollPos = GUILayout.BeginScrollView(scrollPos, options);
        #endregion

        #region Methods
        public void Dispose() => GUILayout.EndScrollView();
        #endregion
    }

    public class HorizontalBlock : IDisposable
    {
        #region Constructors
        public HorizontalBlock(params GUILayoutOption[] options) => GUILayout.BeginHorizontal(options);

        public HorizontalBlock(GUIStyle style, params GUILayoutOption[] options) => GUILayout.BeginHorizontal(style, options);
        #endregion

        #region Methods
        public void Dispose() => GUILayout.EndHorizontal();
        #endregion
    }

    public class ColoredBlock : IDisposable
    {
        #region Constructors
        public ColoredBlock(Color color) => GUI.color = color;
        #endregion

        #region Methods
        public void Dispose() => GUI.color = Color.white;
        #endregion
    }

    [Serializable]
    public class TabsBlock
    {
        #region Fields
        private readonly Dictionary<string, Action> methods;
        private readonly string[] keys;
        private Action currentGuiMethod;
        public int curMethodIndex = -1;
        #endregion

        #region Constructors
        public TabsBlock(Dictionary<string, Action> methods)
        {
            this.methods = methods;
            this.keys = methods.Keys.ToArray();
            SetCurrentMethod(0);
        }
        #endregion

        #region Methods
        public void Draw()
        {
            using (new VerticalBlock(EditorStyles.helpBox))
            {
                using (new HorizontalBlock())
                {
                    for (int i = 0; i < this.keys.Length; i++)
                    {
                        string key = this.keys[i];
                        GUIStyle btnStyle = i == 0 ? EditorStyles.miniButtonLeft : i == (this.keys.Length - 1) ? EditorStyles.miniButtonRight : EditorStyles.miniButtonMid;
                        using (new ColoredBlock(this.currentGuiMethod == this.methods[key] ? Color.grey : Color.white))
                        {
                            if (GUILayout.Button(key, btnStyle))
                            {
                                SetCurrentMethod(i);
                            }
                        }
                    }
                }

                GUILayout.Label(this.keys[this.curMethodIndex], EditorStyles.centeredGreyMiniLabel);
                this.currentGuiMethod();
            }
        }

        public void SetCurrentMethod(int index)
        {
            this.curMethodIndex = index;
            this.currentGuiMethod = this.methods[this.keys[index]];
        }
        #endregion
    }
}