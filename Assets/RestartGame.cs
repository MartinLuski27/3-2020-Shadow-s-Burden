using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour {

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
}
