using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {

	public GameObject DialogueBox;
	public Text DialogueText;
	public string Dialogue;
	public bool DialogueActive;
	public GameObject ghastya;
	public GameObject player;
	public bool hasEnteredAuto = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(DialogueActive)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || hasEnteredAuto)
			{
				if (DialogueBox.activeInHierarchy)
				{
					DialogueBox.SetActive(false);
					ghastya.transform.position = this.gameObject.transform.position;
					ghastya.SetActive(true);
					player.GetComponent<PlayerMovement>().ghastyaUnlocked = true;
					GetComponent<Collider2D>().enabled = false;
					GetComponent<SpriteRenderer>().enabled = false;
					player.GetComponent<PlayerMovement>().enabled = true;
					player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
					this.enabled = false;
				}
				else
				{
					DialogueBox.SetActive(true);
					DialogueText.text = Dialogue;
					hasEnteredAuto = false;
				}
			}
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			DialogueActive = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			DialogueActive = false;
			DialogueBox.SetActive(false);
		}
	}
}
