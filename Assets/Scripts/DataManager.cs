using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int[] topScores = new int[5];
    public string[] topScoresName = new string[5];
    public string playerName;
    public int playerScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    /*
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
    */
}
