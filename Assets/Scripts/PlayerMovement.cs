using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40;
    
    float horizontalMove = 0;
    bool jump = false;

    public GameObject semisolida1;
    public GameObject semisolida2;
    public GameObject semisolida3;

    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Velocidad", Mathf.Abs(horizontalMove));

        //detectar input para saltar y realizar el salto con su animación
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Salto", true);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            resetearSemisolidas();
        }
    }

    public void resetearSemisolidas()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            semisolida1.SetActive(false);
            semisolida2.SetActive(false);
            semisolida3.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D info)
    {
        if (info.gameObject.layer == 11)
            animator.SetBool("Salto", false);
    }
    void OnLanding()
    {
        animator.SetBool("Salto", false);
    }
    
    //Movimiento del jugador que se actualiza cada frame, teniendo habilitado el salto pero no agacharse
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
