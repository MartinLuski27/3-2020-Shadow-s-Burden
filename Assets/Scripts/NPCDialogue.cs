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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.UpArrow) && DialogueActive)
		{
			if(DialogueBox.activeInHierarchy)
			{
				DialogueBox.SetActive(false);
				ghastya.transform.position = this.gameObject.transform.position;
				ghastya.SetActive(true);
				GetComponent<Collider2D>().enabled = false;
				GetComponent<SpriteRenderer>().enabled = false;
				this.enabled = false;
			}
			else
			{
				DialogueBox.SetActive(true);
				DialogueText.text = Dialogue;
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
