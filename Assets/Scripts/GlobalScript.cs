using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour
{
    public static GlobalScript instance;

    [HideInInspector]
    public string playerName;

    [HideInInspector]
    public int playerPoints;


    [HideInInspector]
    public string bestPlayerName;

    [HideInInspector]
    public int bestPlayerPoints;


    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
      
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveInfo()
    {
        LoadInfo();
       
        if (playerPoints > bestPlayerPoints) {
            SaveData data = new SaveData();
            data.name = playerName;
            data.score = playerPoints;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.name;
            bestPlayerPoints = data.score;
        }
    }
}

