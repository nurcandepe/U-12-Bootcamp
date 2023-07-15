using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Sahnelere aktarýlacak bilgiler
    public SOValues values;
    //Paneller
    private GameObject playPanel;
    private GameObject settingsPanel;
    private GameObject creditsPanel;
    //Butonlar
    public Button playButton;
    public Button manButton;
    public Button womanButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button exitButton;
    

    void Start()
    {
        playPanel = GameObject.Find("PlayPanel");
        settingsPanel = GameObject.Find("SettingsPanel");
        creditsPanel = GameObject.Find("CreditsPanel");

        playPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(EnablePlayPanel);
        manButton.onClick.AddListener(StartGameFuncMan);
        womanButton.onClick.AddListener(StartGameWoman);
        settingsButton.onClick.AddListener(EnableSettingsPanel);
        creditsButton.onClick.AddListener(EnableCreditsPanel);
        exitButton.onClick.AddListener(ExitGameFunc);
    }

    private void StartGameFuncMan()
    {
        values.gender = "male";
        values.playerName = "Victor";
        values.map = 10;
        values.quest = 10;
        SceneManager.LoadScene("Base");
    }
    private void StartGameWoman()
    {
        values.gender = "female";
        values.playerName = "Valeria";
        values.map = 10;
        values.quest = 10;
        SceneManager.LoadScene("Base");
    }

    private void ExitGameFunc()
    {
        Application.Quit();
    }

    private void EnablePlayPanel()
    {
        playPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    private void EnableSettingsPanel()
    {
        playPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    private void EnableCreditsPanel()
    {
        playPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

}
