using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayLevel()
    {
        SceneManager.LoadScene("Level01");
    }

    public void QuitLevel()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
