using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoreValue = 5;
    public int attackDamage = 1;
    DieEnemy EplayerHealth;
    EnemyBoss1Behavior BplayerHealth;

    void Awake()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EplayerHealth = other.GetComponent<DieEnemy>();
            EplayerHealth.TakeDamage (attackDamage);
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            BplayerHealth = other.GetComponent<EnemyBoss1Behavior>();
            
            BplayerHealth.TakeDamage(attackDamage);
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
        }
    }
}
