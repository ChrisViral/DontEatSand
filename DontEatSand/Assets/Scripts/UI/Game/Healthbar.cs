using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DontEatSand.Entities;

namespace DontEatSand.UI.Game
{
    public class Healthbar : MonoBehaviour
    {
        private Entity entity;
        private Image healthFill;

        private void Awake()
        {
            entity = GetComponentInParent<Entity>();
            healthFill = GetComponent<Image>();
            healthFill.enabled = false;
        }

        private void Update()
        {
            healthFill.fillAmount = entity.Health / entity.HealthAmount;
            if (entity.IsSelected)
            {
                healthFill.enabled = true;
            }
            else
            {
                healthFill.enabled = false;
            }
        }

    }
}


