using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public GameObject infoPanel;

    public void InfoPanelHandler()
    {
        if (infoPanel.activeSelf == true)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(true);
        }
    }
}
