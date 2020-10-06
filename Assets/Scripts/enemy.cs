using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public int maxHealth = 2;
    int currentHealth;
    public Animator animacionDaño;
    public Animator animacionMuerte;

    void Start()
    {
        currentHealth = maxHealth;
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            animacionDaño.SetTrigger("Daño");
        }
    }
    
    void Die()
    {
        
    }
}
