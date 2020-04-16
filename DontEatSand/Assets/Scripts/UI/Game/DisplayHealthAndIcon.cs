using DontEatSand.Entities;
using DontEatSand.Entities.Units;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class DisplayHealthAndIcon : MonoBehaviour
    {
        #region Fields
        [FormerlySerializedAs("greenHealth"),SerializeField]
        private Image healthbar;
        [SerializeField]
        private Color highHealth = Color.green, lowHealth = Color.red;
        private Image icon;
        private Button button;
        private float smoothSpeed;
        private bool isSandpit;
        private Sandpit sandpit;
        private Entity entity;
        #endregion

        #region Properties
        private ISelectable selected;
        /// <summary>
        /// The unit whose icon and health we want to show
        /// </summary>
        public ISelectable Selected
        {
            get => this.selected;
            set
            {
                this.selected = value;
                this.HasSelection = value != null;
                if (this.HasSelection)
                {
                    //Set icon and check type
                    //ReSharper disable once PossibleNullReferenceException
                    this.icon.sprite = value.Info.Icon;
                    switch (value)
                    {
                        case Sandpit s:
                            this.sandpit = s;
                            this.isSandpit = true;
                            break;

                        case Entity e:
                            this.entity = e;
                            this.isSandpit = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// If this icon has a selection
        /// </summary>
        public bool HasSelection { get; private set; }

        /// <summary>
        /// The amount to display on the bar
        /// </summary>
        private float Amount => this.HasSelection ? this.isSandpit ? this.sandpit.SandAmount : this.entity.HealthAmount : 0f;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the selected object to the one associated to this icon
        /// </summary>
        public void SetSelection()
        {
            if (this.HasSelection && RTSPlayer.Instance.SelectionType == SelectionType.UNITS && this.Selected is Unit)
            {
                RTSPlayer.Instance.ForceSelect(this.Selected);
            }
        }
        #endregion

        #region Functions
        private void Awake()
        {
            this.icon = GetComponent<Image>();
            this.button = GetComponent<Button>();
            this.button.onClick.AddListener(SetSelection);
        }

        private void Update()
        {
            //Updates the unit's health bar
            if(this.Selected != null)
            {
                float fill = Mathf.SmoothDamp(this.healthbar.fillAmount, this.Amount, ref this.smoothSpeed, 0.2f);
                this.healthbar.fillAmount = fill;
                this.healthbar.color = Color.Lerp(this.lowHealth, this.highHealth, fill);
            }
        }
        #endregion
    }
}


