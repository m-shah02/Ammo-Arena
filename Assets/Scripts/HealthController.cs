using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
   public float currentPlayerHealth = 100.0f;
   [SerializeField] private float maxPlayerHealth = 100.0f;
   [SerializeField] private int regenRate = 1;
   private bool canRegen = false;

   [SerializeField] private Image redSplatterImage = null;

   [SerializeField] private Image hurtImage = null;
   [SerializeField] private float hurtTimer = 0.1f;

   [SerializeField] private float healCooldown = 3.0f;
   [SerializeField] private float maxHealCooldown = 3.0f;
   [SerializeField] private bool startCooldown = false;


   [SerializeField] private AudioClip hurtAudio = null;
   private AudioSource healthAudioSource;

   private void Start()
   {
      healthAudioSource = GetComponent<AudioSource>();
   }

   void UpdateHealth()
   {
      Color splatterAlpha = redSplatterImage.color;
      splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
      redSplatterImage.color = splatterAlpha;
   }

   IEnumerator HurtFlash()
   {
      hurtImage.enabled = true;
      healthAudioSource.PlayOneShot(hurtAudio);
      yield return new WaitForSeconds(hurtTimer);
      hurtImage.enabled = false;
   }

   public void TakeDamage(float damage)
   {
      if(currentPlayerHealth >= 0)
      {
         currentPlayerHealth -= damage;
         canRegen = false;
         StartCoroutine(HurtFlash());
         UpdateHealth();
         healCooldown = maxHealCooldown;
         startCooldown = true;
      }

   }

   void Update()
   {
      if(startCooldown)
      {
         healCooldown -= Time.deltaTime;
         if(healCooldown <= 0)
         {
            canRegen = true;
            startCooldown = false;
         }
      }

      if(canRegen)
      {
         if(currentPlayerHealth <= maxPlayerHealth - 0.01)
         {
            currentPlayerHealth += Time.deltaTime * regenRate;
            UpdateHealth();
         }
         else
         {
            currentPlayerHealth = maxPlayerHealth;
            healCooldown = maxHealCooldown;
            canRegen = false;
         }
      }
   }
}
