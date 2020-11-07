using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaRodadera : MonoBehaviour {

    public float speed = 10;

    void Update()
    {
        this.gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
	public void Teleport()
    {
        this.gameObject.transform.position = new Vector3(290, transform.position.y, 0f);
    }
}
