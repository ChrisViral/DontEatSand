using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    [RequireComponent(typeof(RectTransform), typeof(Image), typeof(Button))]
    public class QueueIcon : MonoBehaviour
    {
        #region SerializedField
        private RectTransform rect;
        private Image icon;
        private Button button;
        #endregion

        #region Properties
        /// <summary>
        /// Info of the unit associated to this icon
        /// </summary>
        public UnitInfo Info { get; private set; }

        /// <summary>
        /// The percentage of the icon that is filled in
        /// </summary>
        public float FillAmount
        {
            get => this.icon.fillAmount;
            set => this.icon.fillAmount = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets up the queue icon for use
        /// </summary>
        /// <param name="info">UnitInfo to setup with</param>
        /// <param name="call">Function to execute if clicked on</param>
        public void Setup(UnitInfo info, UnityAction call)
        {
            this.Info = info;
            //this.rect.anchoredPosition = Vector3.zero;
            this.icon.sprite = info.Icon;
            this.button.onClick.AddListener(call);
        }
        #endregion

        #region Functions
        private void Awake()
        {
            this.icon = GetComponent<Image>();
            this.button = GetComponent<Button>();
            this.rect = this.icon.rectTransform;
        }
        #endregion
    }
}
