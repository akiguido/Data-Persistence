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
    
    public void SavePlayerName()
    {
        playerName = NameField.text;

    }
    public void StartNew()
    {
        GameManager.Instance.playerName = playerName;
        print("Nome : " + playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR   
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
//        MainManager.Instance.SaveColor();
    }


}
