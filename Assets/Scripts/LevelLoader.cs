using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {


    public Animator Transition;
    public float transitionTime = 1f;
    public GameObject gameManager;
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        this.gameManager = GameObject.Find("GameManager");

        gameManager.GetComponent<DontDestroy>().health = player.GetComponent<PlayerHealth>().currentHealth;
        gameManager.GetComponent<DontDestroy>().moralidad = player.GetComponent<PlayerHealth>().moralidad;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadPrevLevel()
    {
        this.gameManager = GameObject.Find("GameManager");

        gameManager.GetComponent<DontDestroy>().health = player.GetComponent<PlayerHealth>().currentHealth;
        gameManager.GetComponent<DontDestroy>().moralidad = player.GetComponent<PlayerHealth>().moralidad;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }


    IEnumerator LoadLevel(int LevelIndex)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
