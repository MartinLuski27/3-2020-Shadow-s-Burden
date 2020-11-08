using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGhastya : MonoBehaviour {

    public float speed;
    public Transform pos;
    float scaleX;
    float scaleY;
    float scaleZ;
    bool isFlipped = false;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = Vector3.forward * -1;
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.forward * 0;
        }*/
        if (pos.position.x > target.position.x && isFlipped == false)
        {
            scaleX = pos.localScale.x;
            scaleY = pos.localScale.y;
            scaleZ = pos.localScale.z;
            pos.localScale = new Vector3(scaleX * -1, scaleY, scaleZ);
            isFlipped = true;
        }
        if (pos.position.x < target.position.x && isFlipped == true)
        {
            scaleX = pos.localScale.x;
            scaleY = pos.localScale.y;
            scaleZ = pos.localScale.z;
            pos.localScale = new Vector3(scaleX * -1, scaleY, scaleZ);
            isFlipped = false;
        }

        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } 
    }
}