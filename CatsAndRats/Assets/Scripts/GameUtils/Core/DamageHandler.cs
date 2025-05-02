using UnityEngine;
using UnityEngine.UI;

namespace GameUtils.Core
{
    /*
    * this is a simple script that allow to handle UI and take damage
    * we usually attach this script to a GameObject cat/mouse player.
    */
    [AddComponentMenu("DamageHandler")]
    public class DamageHandler : MonoBehaviour
    {
        [SerializeField] public float MaxHealth = 100f;
        [SerializeField] public float CurrentHealth = 100f;
        [SerializeField] public Canvas HealthUI;

        public void Start()
        {
            // Start logic here
        }

        public void Update()
        {
            checkDeath();
            UpdateHealthUI();
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
        }

        private void UpdateHealthUI()
        {
            Slider healthSlider = HealthUI.GetComponentInChildren<Slider>();
            if (healthSlider != null)
            {
                healthSlider.value = CurrentHealth / MaxHealth;
            }
            else
            {
                Debug.LogWarning("Health UI not found");
            }
        }
        private void checkDeath()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        internal void InstantDie()
        {
            CurrentHealth = 0;
        }
    }
}
