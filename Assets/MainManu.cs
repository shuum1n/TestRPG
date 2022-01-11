using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TownScreen");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
