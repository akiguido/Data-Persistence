using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public string playerName;
    public TMP_InputField NameField;
    public TMP_Text PlayerNameText;
    public TMP_Text BestPlayerText;
    public TMP_Text BestScoreText;

    public void Start()
    {
        GameManager.Instance.LoadPlayer();
        BestPlayerText.text = GameManager.Instance.BestPlayer;
        BestScoreText.text = GameManager.Instance.BestScore.ToString();

        if (GameManager.Instance.playerName != "")
        {
            NameField.text = GameManager.Instance.playerName;
        }

    }

    public void SavePlayerName()
    {
        
        playerName = NameField.text;
        PlayerNameText.text = playerName;
    }
    public void StartNew()
    {
        GameManager.Instance.playerName = playerName;
//        print("Nome : " + playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR   
        GameManager.Instance.SavePlayer();
        EditorApplication.ExitPlaymode();
#else
        GameManager.Instance.SavePlayer();
        Application.Quit();
#endif
    }


}
