using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
        [SerializeField] private AudioClip HealingSound;
        [SerializeField] protected AudioClip DamageSound;
        [SerializeField] private AudioClip DieSound;
        private float damageCooldown = 1.0f; // secondi di invulnerabilità
        private float lastDamageTime = -Mathf.Infinity;


        private bool isDead = false;

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
            // cooldown, ignore damage
            if (Time.time - lastDamageTime < damageCooldown)
                return;

            lastDamageTime = Time.time; // last damage 

            if (damage > 0)
            {
                if (CurrentHealth >= damage)
                {
                    CurrentHealth -= damage;
                }
                else CurrentHealth = 0;
            }
            gameObject.GetComponent<AudioSource>().PlayOneShot(DamageSound);
        }

        public void Heal(float healValue)
        {
            if (healValue <= 0) return;

            if(healValue + CurrentHealth < MaxHealth)
            {
                CurrentHealth += healValue;
            }
            else CurrentHealth = MaxHealth;

            gameObject.GetComponent<AudioSource>().PlayOneShot(HealingSound);
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
            if (CurrentHealth <= 0 && !isDead)
            {
                //Destroy(gameObject);
                isDead = true;
                Die();
                return;
            }
        }

        private void Die()
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(DieSound);
        }

        internal void InstantDie()
        {
            CurrentHealth = 0;
        }
    }
}
