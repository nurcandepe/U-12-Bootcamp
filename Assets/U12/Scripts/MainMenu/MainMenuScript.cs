using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private GameObject playPanel;
    private GameObject creditsPanel;
    private GameObject settingsPanel;

    void Start()
    {
        playPanel = GameObject.Find("PlayPanel");
        creditsPanel = GameObject.Find("CreditsPanel");
        settingsPanel = GameObject.Find("SettingsPanel");

        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
