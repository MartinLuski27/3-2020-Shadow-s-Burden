using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayTrigger : MonoBehaviour
{
    public EdgeCollider2D semisolida;
    private void OnTriggerEnter2D()
    {
        semisolida.enabled = true;
    }
}
