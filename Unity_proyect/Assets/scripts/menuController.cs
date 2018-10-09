using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

    public void SartGame()
    {
        SceneManager.LoadScene("OnGame");
    }

    public void ExitGame()
    {
        Debug.Log("Exit :D");
        Application.Quit();
    }
}
