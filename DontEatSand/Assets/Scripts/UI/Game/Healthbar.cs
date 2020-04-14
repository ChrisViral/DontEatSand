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
        }

        private void Update()
        {
            healthFill.fillAmount = entity.Health / entity.HealthAmount;
        }

    }
}


