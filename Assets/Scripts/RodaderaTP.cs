using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaderaTP : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.tag == "bordePatrol")
        {
            collInfo.gameObject.GetComponent<PlantaRodadera>().Teleport();
        }
    }
}
