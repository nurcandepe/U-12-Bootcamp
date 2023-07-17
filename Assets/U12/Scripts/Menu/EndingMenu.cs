using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{

    public Button menuButton;

    private void OnEnable()
    {
        menuButton.onClick.AddListener(ReturnMainMenu);
    }

    private void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
