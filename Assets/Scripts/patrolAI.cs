using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAI : MonoBehaviour
{

    public float speed;

    public float distance;

    private bool movingLeft = true;

    public Transform groundDetection;


    // Update is called once per frame
    void Update()
    {
        //Mueve al enemigo ahcia la derecha en el eje Y
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //Linea invisible aparentada al jugador, que apunta hacia abajo para detectar la plataforma, e informa cuando no lo hace para que el jugador cambie su dirección
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingLeft == true)
            {
                //Rota el sprite del jugador horizontalmente y deja de avanzar hacia la derecha, por lo que avanza hacia la izquierda
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = false;
            }
            else
            {
                //Opuesto a lo de arriba
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = true;
            }
        }
    }
}
