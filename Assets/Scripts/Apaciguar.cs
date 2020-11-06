using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Apaciguar : MonoBehaviour {
    public Animator animator;
    public Transform PuntoApaciguar;
    public LayerMask enemyLayer;
    public GameObject gameManager;
    bool canAppease = false;
    public AudioSource gemUse;

    public float Rango = 0.5f;

    public float AppeaseRate = 1f;
    float NextAppeaseTime = 0f;

    void Update()
    {
        this.gameManager = GameObject.Find("GameManager");
        canAppease = gameManager.GetComponent<DontDestroy>().hasGem;

        if (Time.time > +NextAppeaseTime)
        {
            if (Input.GetKeyDown(KeyCode.C) && canAppease)
            {
                Appease();
                NextAppeaseTime = Time.time + 1f / AppeaseRate;
            }
        }

    }
    void Appease()
    {
        animator.SetTrigger("Apaciguar");
        gemUse.Play();
        AppeaseArea();
    }

    public void AppeaseArea()
    {
        Collider2D[] apaciguarEnemigo = Physics2D.OverlapCircleAll(PuntoApaciguar.position, Rango, enemyLayer);
        
        foreach (Collider2D enemy in apaciguarEnemigo)
        {
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                enemy.GetComponent<EnemyHealth>().Appeased();
                this.gameObject.GetComponent<PlayerHealth>().moralidad++;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PuntoApaciguar == null)
            return;

        Gizmos.DrawWireSphere(PuntoApaciguar.position, Rango);
    }
}
