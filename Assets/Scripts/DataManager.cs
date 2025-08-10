using UnityEngine;
using System.IO;
using TMPro;
public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

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
