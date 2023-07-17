using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePlayerName : MonoBehaviour
{
    private TextMeshProUGUI playerNameText;
    public SOValues values;
    void Start()
    {
        playerNameText = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
        playerNameText.text = values.playerName;
    }

    void Update()
    {
        
    }
}
