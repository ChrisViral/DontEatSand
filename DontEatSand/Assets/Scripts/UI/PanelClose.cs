using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI
{
    /// <summary>
    /// Closes the given panel on button click
    /// </summary>
    [DisallowMultipleComponent, RequireComponent(typeof(Button))]
    public class PanelClose : MonoBehaviour
    {
        #region Fields
        //Inspector fields
        [SerializeField]
        private GameObject panel;   //Panel to close
        #endregion

        #region Methods
        /// <summary>
        /// Event to fire on button click
        /// </summary>
        private void OnClick() => this.panel.SetActive(false);
        #endregion

        #region Functions
        private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);
        #endregion
    }
}
