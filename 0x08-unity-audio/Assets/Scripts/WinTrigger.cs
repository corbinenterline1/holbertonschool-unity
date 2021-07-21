using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public Timer time;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && time.GetComponent<Timer>().enabled == true)
        {
            time.GetComponent<Timer>().enabled = false;
            time.GetComponent<Timer>().TimerText.color = Color.green;
            time.GetComponent<Timer>().TimerText.fontSize = 60;
        }
    }
}
