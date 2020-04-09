using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand;


namespace DontEatSand.UI
{
    public class UpdateCounter : MonoBehaviour
    {
        private int sandCount;
        private int maxCandyCount;
        private int usedCandyCount;

        [SerializeField]
        private Text sandCounter;
        [SerializeField]
        private Text candyCounter;
        
        /// <summary>
        /// Change in candy total
        /// </summary>
        /// <param name="amount"></param>
        private void OnCandyMaxChanged(int amount)
        {
            this.maxCandyCount += amount;
            this.candyCounter.text = string.Format("{0}/{1}", usedCandyCount, maxCandyCount);
        }
        /// <summary>
        /// Change in sand amount
        /// </summary>
        /// <param name="amount">Amount of sand added or removed</param>
        private void OnSandChanged(int amount)
        {
            this.sandCount += amount;
            this.sandCounter.text = sandCount.ToString();
        }

        /// <summary>
        /// Change in used candy amount
        /// </summary>
        /// <param name="amount">Candy used or freed</param>
        private void OnCandyChanged(int amount)
        {
            this.usedCandyCount += amount;
            this.candyCounter.text = string.Format("{0}/{1}", usedCandyCount, maxCandyCount);;
        }


        #region Functions

        private void Awake()
        {
            GameEvents.OnCandyMaxChanged.AddListener(OnCandyMaxChanged);
            GameEvents.OnSandChanged.AddListener(OnSandChanged);
            GameEvents.OnCandyChanged.AddListener(OnCandyChanged);
        }

        private void Start()
        {
            Debug.Log(GameLogic.Player.Sand);
            sandCount = GameLogic.Player.Sand;
            maxCandyCount = GameLogic.Player.MaxCandy;
            usedCandyCount = GameLogic.Player.UsedCandy;

            sandCounter.text = sandCount.ToString();
            candyCounter.text = string.Format("{0}/{1}", usedCandyCount, maxCandyCount);

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

