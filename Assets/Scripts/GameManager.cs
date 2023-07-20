using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int score;

    public string BestPlayer = "";
    public int BestScore = 0;

    public void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }

    // Update is called once per frame
    public void UpdateBestPlayer(string pl, int sc)
    {
        if (sc > BestScore)
        {
            BestScore = sc;
            BestPlayer = pl;
            SavePlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.BestPlayer = BestPlayer;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/recordFile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/recordFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.BestPlayer;
            BestScore = data.BestScore;
        }
    }


}
