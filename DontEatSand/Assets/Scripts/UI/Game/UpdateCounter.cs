using UnityEngine;
using UnityEngine.UI;

namespace DontEatSand.UI.Game
{
    public class UpdateCounter : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Text sandCounter;
        [SerializeField]
        private Text candyCounter;
        private int sandCount;
        private int maxCandyCount;
        private int usedCandyCount;
        #endregion

        #region Methods
        /// <summary>
        /// Change in candy total
        /// </summary>
        /// <param name="amount"></param>
        private void OnCandyMaxChanged(int amount)
        {
            this.maxCandyCount += amount;
            this.candyCounter.text = $"{this.usedCandyCount}/{this.maxCandyCount}";
        }

        /// <summary>
        /// Change in sand amount
        /// </summary>
        /// <param name="amount">Amount of sand added or removed</param>
        private void OnSandChanged(int amount)
        {
            this.sandCount -= amount;
            this.sandCounter.text = this.sandCount.ToString();
        }

        /// <summary>
        /// Change in used candy amount
        /// </summary>
        /// <param name="amount">Candy used or freed</param>
        private void OnCandyChanged(int amount)
        {
            this.usedCandyCount += amount;
            this.candyCounter.text = $"{this.usedCandyCount}/{this.maxCandyCount}";
        }
        #endregion

        #region Functions
        private void Awake()
        {
            GameEvents.OnCandyMaxChanged.AddListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.AddListener(OnSandChanged);
            GameEvents.OnCandyChanged.AddListener(OnCandyChanged);
        }

        private void Start()
        {
            this.sandCount = RTSPlayer.Instance.Sand;
            this.maxCandyCount = RTSPlayer.Instance.MaxCandy;
            this.usedCandyCount = RTSPlayer.Instance.UsedCandy;

            this.sandCounter.text = this.sandCount.ToString();
            this.candyCounter.text = $"{this.usedCandyCount}/{this.maxCandyCount}";

        }

        private void OnDestroy()
        {
            //Remove event listeners
            GameEvents.OnCandyMaxChanged.RemoveListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.RemoveListener(OnSandChanged);
            GameEvents.OnCandyChanged.RemoveListener(OnCandyChanged);
        }
        #endregion
    }
}

