using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAI : MonoBehaviour
{

    public float speed;
    private bool isFlipped = false;
    public Transform transformMomia;

    float scaleX;
    float scaleY;
    float scaleZ;

    // Update is called once per frame
    void Update()
    {
        if (isFlipped == false)
            //Mueve al enemigo hacia la izquierda en el eje X
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else if (isFlipped == true)
            //Mueve al enemigo hacia la derecha en el eje X
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public void flip()
    {
        if (isFlipped == false)
        {
            scaleX = transformMomia.localScale.x;
            scaleY = transformMomia.localScale.y;
            scaleZ = transformMomia.localScale.z;
            transformMomia.localScale = new Vector3(scaleX * -1, scaleY, scaleZ);
            isFlipped = true;
        }
        else if (isFlipped == true)
        {
            scaleX = transformMomia.localScale.x;
            scaleY = transformMomia.localScale.y;
            scaleZ = transformMomia.localScale.z;
            transformMomia.localScale = new Vector3(scaleX * -1, scaleY, scaleZ);
            isFlipped = false;
        }
    }
}
