using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float enemyDamage = 10.0f;
    [SerializeField] private HealthController healthController = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Directly call the TakeDamage method and handle health deduction inside HealthController
            healthController.TakeDamage(enemyDamage);

        }
    }
}
