using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {


    public Animator Transition;
    public float transitionTime = 1f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


    IEnumerator LoadLevel(int LevelIndex)
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
