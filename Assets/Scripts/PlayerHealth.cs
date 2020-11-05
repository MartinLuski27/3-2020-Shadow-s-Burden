using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int currentHealth;
    public Transform respawnPoint;
    public Transform resPointGhastya;
    public GameObject player;
    public float deathDelay = 2;
    public AudioSource hurtSound;
    public int moralidad = 0;
    public GameObject gameManager;
    public HealthBar healthBar;
    public Animator animator;
    public bool canTakeDamage = true;
    public Transform ghastya;
    public Animator AIjefe;
    public LevelLoader levelLoader;
    public bool canHeal;
    bool healingEnabled = true;
    public bool completeHealing = true;
    public AudioSource healCharge;
    public AudioSource healComplete;

    void Awake()
    {
        this.gameManager = GameObject.Find("GameManager");
    }

    // Use this for initialization
    //El jugador comienza con la máxima salud y se muestra en la barra de vida
    void Start() {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = gameManager.GetComponent<DontDestroy>().health;
        healthBar.SetHealth(currentHealth);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(1);
        }
        if (currentHealth < maxHealth)
        {
            canHeal = true;
        }
    }

    //El jugador recibe daño y se disminuye en la cantidad de daño recibido su vida
    public void takeDamage(int damage)
    {
        if (canTakeDamage)
        {
            completeHealing = false;
            healCharge.Stop();
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth > 0)
                animator.SetTrigger("Hurt");
            hurtSound.Play();

            if (currentHealth <= 0f)
            {
                Die();
            }
        }
    }
    public void Heal(int healing)
    {
        if (canHeal && healingEnabled)
        {
            completeHealing = true;
            healCharge.Play();
            animator.SetTrigger("forceIdle");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<AtaqueMele>().enabled = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            canHeal = false;
            StartCoroutine(healDelay(3, 1, 5));
        }
    }

    IEnumerator healDelay(float delay, int hp, float cooldown)
    {
        healingEnabled = false;
        yield return new WaitForSeconds(delay);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<AtaqueMele>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if (completeHealing)
        {
            healComplete.Play();
            currentHealth += hp;
            healthBar.SetHealth(currentHealth);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        yield return new WaitForSeconds(cooldown);
        healingEnabled = true;
    }

    void Die()
    {
        animator.SetTrigger("Muerto");
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<AtaqueMele>().enabled = false;
        player.GetComponent<PlayerMovement>().resetearSemisolidas();
        canTakeDamage = false;
        StartCoroutine(ResetPos());
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(deathDelay);
        player.transform.position = respawnPoint.position;
        ghastya.position = resPointGhastya.position;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<AtaqueMele>().enabled = true;
        canTakeDamage = true;
        currentHealth = maxHealth;
        canHeal = false;
        healthBar.SetMaxHealth(maxHealth);
        animator.SetTrigger("Respawn");

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AIjefe.enabled = false;
            levelLoader.LoadPrevLevel();
        }
    }
}
