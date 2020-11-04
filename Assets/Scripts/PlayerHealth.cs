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
    }

    //El jugador recibe daño y se disminuye en la cantidad de daño recibido su vida
    public void takeDamage(int damage)
    {
        if (canTakeDamage)
        {
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

    void Die()
    {
        animator.SetTrigger("Muerto");
        player.GetComponent<PlayerMovement>().enabled = false;
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
        canTakeDamage = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator.SetTrigger("Respawn");

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AIjefe.enabled = false;
            levelLoader.LoadPrevLevel();
        }
    }
}
