using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int[] topScores = new int[5];
    public string[] topScoresName = new string[5];
    public string playerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadFromFile();
    }
    public void NewEntry(int playerScore, string name)
    {
        bool once = false;
        int tempScore;
        string tempName;
        for (int i = 0; i < topScores.Length; i++)
        {
            if (playerScore > topScores[i])
            {
                tempScore = topScores[i];
                topScores[i] = playerScore;
                playerScore = tempScore;

                tempName = topScoresName[i];
                topScoresName[i] = name;
                name = tempName;
                once = true;
            }
            else if (playerScore == topScores[i] && once)
            {
                tempScore = topScores[i];
                topScores[i] = playerScore;
                playerScore = tempScore;

                tempName = topScoresName[i];
                topScoresName[i] = name;
                name = tempName;
                once = true;
            }
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int[] topScores = new int[5];
        public string[] topScoresName = new string[5];
        public string playerName;
    }
    public void SaveToFile()
    {
        SaveData data = new SaveData();
        data.topScores = topScores;
        data.topScoresName = topScoresName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadFromFile()
    { 
         string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topScores = data.topScores;
            topScoresName = data.topScoresName;
        }
    }

}
