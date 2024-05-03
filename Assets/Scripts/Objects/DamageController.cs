using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float enemyDamage = 10.0f;
    [SerializeField] private HealthController healthController = null;
    public int health = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Directly call the TakeDamage method and handle health deduction inside HealthController
            healthController.TakeDamage(enemyDamage);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
        Die();
        }
    }

    private void Die()
    {
        // Code to handle the zombie's death
        Destroy(gameObject);  // Destroys the zombie object
    }
}
