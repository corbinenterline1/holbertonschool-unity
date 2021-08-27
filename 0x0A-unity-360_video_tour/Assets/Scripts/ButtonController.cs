using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Animator ScreenFade_Anim;
    public Animator ButtonFade_Anim;
    public string sceneName;
    // public GameObject Fader;

    public void SceneSwap()
    {
        Debug.Log("Switching to scene " + sceneName);
        StartCoroutine(sceneDelay(sceneName));
    }

    IEnumerator sceneDelay(string scene)
    {
        while (true)
        {
            Debug.Log("After fade starting 4 second wait for " + scene);
            ButtonFade_Anim.SetTrigger("ButtonTrigger");
            ScreenFade_Anim.SetTrigger("FaderTrigger");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(scene);

        }
    }
}