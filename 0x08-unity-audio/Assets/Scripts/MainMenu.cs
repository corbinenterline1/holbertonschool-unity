using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level.ToString());
    }
    // Start is called before the first frame update
    public void Options()
    {
        PlayerPrefs.SetString("sceneHistory", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
