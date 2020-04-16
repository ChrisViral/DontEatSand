using DontEatSand.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    [RequireComponent(typeof(Image))]
    public class DisplayHealthAndIcon : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Image greenHealth;
        private Image icon;
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
                if (value != null)
                {
                    //Set icon and check type
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
        /// The amount to display on the bar
        /// </summary>
        private float Amount => this.isSandpit ? this.sandpit.SandAmount : this.entity.HealthAmount;
        #endregion

        #region Functions
        private void Awake() => this.icon = GetComponent<Image>();

        private void Update()
        {
            //Updates the unit's health bar
            if(this.Selected != null)
            {
                this.greenHealth.fillAmount = Mathf.SmoothDamp(this.greenHealth.fillAmount, this.Amount, ref this.smoothSpeed, 0.2f);
            }
        }
        #endregion
    }
}


