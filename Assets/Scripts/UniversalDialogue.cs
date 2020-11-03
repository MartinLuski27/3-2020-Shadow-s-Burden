using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniversalDialogue : MonoBehaviour {

	//EN LA VARIABLE TEXT ESCRIBEN EL TEXTO PROPIO. ESTE SCRIPT SOLO AGUANTA UNA PANTALLA DE TEXTO
	//NO PUEDE PASAR MAS DE 5-6 RENGLONES
	//RECUERDEN TAMBIEN QUE DEBEN TENER EN EL CANVAS UN GAMEOBJECT IMAGE Y UN GAMEOBJECT TEXT Y DEMAS, Y LOS REFERENCIAN
	//EL DIALOGO LO ESCRIBEN DESDE EL INSPECTOR EN LA VARIABLE STRING "DIALOGUE", Y SI, ES UNA MIERDA PERO BUE

	public GameObject DialogueBox;
	public Text DialogueText; 
	public string Dialogue;
	public bool DialogueActive;

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
