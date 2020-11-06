using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public GameObject gameManager;
    public bool hasGem;
    public AudioSource pickupSound;

    private void Start()
    {
        hasGem = gameManager.GetComponent<DontDestroy>().hasGem;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Awake()
    {
        this.gameManager = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hasGem = true;
            gameManager.GetComponent<DontDestroy>().hasGem = hasGem;
            pickupSound.Play();

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Se recoge el objeto y se guarda acá
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        
    }
}
