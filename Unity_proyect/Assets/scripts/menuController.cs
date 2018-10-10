using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
    public GameObject Canvas;

    public void LoadScene (string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Debug.Log("Exit :D");
        Application.Quit();
    }

    public void EnableCanvas()
    {
        if (Canvas.activeSelf == true)
            Canvas.SetActive(false);
        else
            Canvas.SetActive(true);
    }
}
