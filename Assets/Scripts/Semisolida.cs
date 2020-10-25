using JetBrains.Annotations;
using UnityEngine;

public class Semisolida : MonoBehaviour {

    public GameObject linea;

	void OnTriggerEnter2D(Collider2D other)
    {
        linea.SetActive(true);
    }

}
