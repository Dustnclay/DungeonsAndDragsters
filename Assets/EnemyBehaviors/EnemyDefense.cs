using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDefense : MonoBehaviour
{ 

    [SerializeField] float health = 1f;
    [SerializeField] float maxHealth = 1f;


    void Start()
    {
        health = maxHealth;

    }
    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
