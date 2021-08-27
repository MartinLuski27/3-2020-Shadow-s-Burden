using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Remoting.Messaging;

public class DontDestroy : MonoBehaviour {

	public int moralidad = 0;
	public bool hasGem = false;
	public int health = 5;
	GameObject noRespawnEnemy;
	public bool specialSpawnPoint = false;
	GameObject player;
	public GameObject ghastya;
    public Slider sliderVol;
    public float volumenValorSlider = 0;

	public List<string> noRespawnEnemies = new List<string>(); //list de los nombres de los enemigos

	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
    {
		SceneManager.LoadScene(1);
    }

	void OnLevelWasLoaded()
    {
		if (SceneManager.GetActiveScene().buildIndex == 1)
        {
			ResetValues();
        }

        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            sliderVol = GameObject.Find("Slider").GetComponent<Slider>();
            GameObject.Find("OpcionesMenu").SetActive(false);
            sliderVol.value = volumenValorSlider;
        }

        foreach (string enemyName in noRespawnEnemies)
        {
			noRespawnEnemy = GameObject.Find(enemyName); //usar los nombres de la lista para encontrar a los enemigos, uno por uno
			if (noRespawnEnemy != null)
			{
				noRespawnEnemy.SetActive(false); //deshabilitar el enemigo encontrado
				noRespawnEnemy = null; //resetear la variable para encontrar nuevos enemigos
			}
        }

		if (specialSpawnPoint)
        {
			Destroy(GameObject.Find("Ghastya - NPC"));
			if (hasGem) Destroy(GameObject.Find("ObjetoPickUp"));

			ghastya = GameObject.Find("Ghastya");
			if (ghastya != null) ghastya.SetActive(true);

			player = GameObject.Find("Player");
			player.GetComponent<PlayerMovement>().ghastyaUnlocked = true;
			player.transform.position = new Vector3(80f, -3f, 0f);
			specialSpawnPoint = false;
        }
    }

	void ResetValues()
    {
		moralidad = 0;
		hasGem = false;
		health = 5;
		specialSpawnPoint = false;
		player = null;
		ghastya = null;
		noRespawnEnemy = null;
		noRespawnEnemies.Clear();
	}
}
