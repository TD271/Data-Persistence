using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

public class MenuDataManager : MonoBehaviour{
    
    public static MenuDataManager Instance;
    public string playerName;
    public int playerScore;
    public string recordName;
    public int recordScore;

    [System.Serializable]
    class SaveData{
        public string recordName;
        public int recordScore;
    }
    
    public void saveGame(){
        SaveData output= new SaveData();
        output.recordName = playerName;
        output.recordScore = playerScore;
        string json = JsonUtility.ToJson(output);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadGame(){
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            recordName = data.recordName;
            recordScore = data.recordScore;
        }
    }

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath + "/savefile.json");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Instance.loadGame();
    }
}