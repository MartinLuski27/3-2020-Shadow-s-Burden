using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int currentHealth;

    public GameObject player;
    public float deathDelay = 2;

    public AudioSource hurtSound;

    public int moralidad = 0;

    public GameObject gameManager;

    public HealthBar healthBar;

    public Animator animator;

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
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        hurtSound.Play();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Muerto", true);
        player.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(ResetPos());
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(deathDelay);
        player.transform.position = new Vector3(-69f, -3.75f, 0f);
        player.GetComponent<PlayerMovement>().enabled = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
}
