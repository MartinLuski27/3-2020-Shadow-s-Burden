using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;
    
    // Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.D))
        {
            takeDamage(1);
        }
	}

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
