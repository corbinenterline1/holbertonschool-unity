using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer time;
    
    // Activate timer on leaving the trigger
    void OnTriggerExit(Collider other) {
        if (other.name == "Player" && time.GetComponent<Timer>().enabled == false) 
        {
            time.GetComponent<Timer>().TimerText.color = Color.white;
            time.GetComponent<Timer>().TimerText.fontSize = 48;
            time.GetComponent<Timer>().enabled = true;
            time.GetComponent<Timer>().startTime = Time.time;
        }
    }
}