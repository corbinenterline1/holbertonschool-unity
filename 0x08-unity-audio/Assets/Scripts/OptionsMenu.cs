using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        string currentscene = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(currentscene);
    }
}
