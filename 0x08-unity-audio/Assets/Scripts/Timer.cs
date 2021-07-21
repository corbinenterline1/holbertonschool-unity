using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TimerText;
    public float startTime;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        
        string minutes = ((int) t / 60).ToString("00");
        string seconds = (t % 60f).ToString("00.00");
        TimerText.text = minutes + ":" + seconds;
    }
}
