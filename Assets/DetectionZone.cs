using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.name == "Player")
        {
            transform.parent.GetComponent<AI>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.name == "Player")
        {
            transform.parent.GetComponent<AI>().enabled = false;
        }
    }
}
