using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaderaTP : MonoBehaviour {

    public GameObject rodadera;

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.tag == "bordePatrol")
        {
            rodadera.GetComponent<PlantaRodadera>().Teleport();
        }
    }
}
