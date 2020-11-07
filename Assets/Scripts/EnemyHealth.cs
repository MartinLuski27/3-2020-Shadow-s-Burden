using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    //ESTE SCRIPT VA EN LOS ENEMIGOS

    public int maxHealth = 2;
    int currentHealth;
    public Animator animator;
    public GameObject enemigo;
    public GameObject jugador;
    GameObject gameManager;

    public int attackDamage2 = 1;
    bool canDie = true;
	
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
    

    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.Find("GameManager");
	}

    void Update()
    {
        //Attack();
    }

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.name == "Player")
        {
            jugador = collInfo.gameObject;
            jugador.GetComponent<PlayerHealth>().takeDamage(attackDamage2);
            
            this.enabled = false;
            StartCoroutine(iFrames());
        }
    }
    IEnumerator iFrames()
    {
        yield return new WaitForSeconds(1f);
        this.enabled = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0 && canDie)
        {
            Die();
        }
        else if (canDie)
        {
            animator.SetTrigger("Hurt");
        }
    }
    
    void Die()
    {
        //Aca santi, que sabe, haga para que se destruya al morir, porque yo no puedo hacer cosas con las animaciones
        animator.SetBool("Muerto", true);
		enemigo.GetComponent<Collider2D>().enabled = false;
        gameManager.GetComponent<DontDestroy>().noRespawnEnemies.Add(this.gameObject.name);
        switch (gameObject.name)
        {
            case "momia1":
                enemigo.GetComponent<patrolAI>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "momia2":
                enemigo.GetComponent<patrolAI>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "momia3":
                enemigo.GetComponent<patrolAI>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;

            case "rodadera1":
                enemigo.GetComponent<PlantaRodadera>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "rodadera2":
                enemigo.GetComponent<PlantaRodadera>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "rodadera3":
                enemigo.GetComponent<PlantaRodadera>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "rodadera4":
                enemigo.GetComponent<PlantaRodadera>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;
            case "rodadera5":
                enemigo.GetComponent<PlantaRodadera>().enabled = false;
                enemigo.GetComponent<Collider2D>().enabled = false;
                break;

        }
        jugador.GetComponent<PlayerHealth>().moralidad--;
        StartCoroutine(Desaparecer());
    }

    void AppeasedPlant()
    {
        enemigo.GetComponent<Rigidbody2D>().gravityScale = 1;
        enemigo.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        enemigo.GetComponent<Collider2D>().isTrigger = false;
    }

    public void Appeased()
    {
        if (canDie)
        {
            canDie = false;
            gameManager.GetComponent<DontDestroy>().noRespawnEnemies.Add(this.gameObject.name);
            switch (gameObject.name)
            {
                case "momia1":
                    enemigo.GetComponent<patrolAI>().enabled = false;
                    enemigo.GetComponent<Collider2D>().enabled = false;
                    break;
                case "momia2":
                    enemigo.GetComponent<patrolAI>().enabled = false;
                    enemigo.GetComponent<Collider2D>().enabled = false;
                    break;
                case "momia3":
                    enemigo.GetComponent<patrolAI>().enabled = false;
                    enemigo.GetComponent<Collider2D>().enabled = false;
                    break;

                case "rodadera1":
                    enemigo.GetComponent<PlantaRodadera>().enabled = false;
                    AppeasedPlant();
                    break;
                case "rodadera2":
                    enemigo.GetComponent<PlantaRodadera>().enabled = false;
                    AppeasedPlant();
                    break;
                case "rodadera3":
                    enemigo.GetComponent<PlantaRodadera>().enabled = false;
                    AppeasedPlant();
                    break;
                case "rodadera4":
                    enemigo.GetComponent<PlantaRodadera>().enabled = false;
                    AppeasedPlant();
                    break;
                case "rodadera5":
                    enemigo.GetComponent<PlantaRodadera>().enabled = false;
                    AppeasedPlant();
                    break;
            }
            animator.SetBool("Appeased", true);
        }
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
    
    /*
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().takeDamage(attackDamage2);
		}
	}

	void OnDrawGizmosSelected()
	{
        //esto dibuja el circulo donde ta la hitbox de ataque, hay que mover los valores de offset y attackrange que quede bien
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
    */
}
