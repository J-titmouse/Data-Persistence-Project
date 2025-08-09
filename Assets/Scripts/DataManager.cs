using UnityEngine;
using System.IO;
public class DataManager : MonoBehaviour
{
    public static MainManager Instance;
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
    [System.Serializable]

    public void SaveHighScoors()
    {

    }
    public void LoadHighScoors()
    { 
        
    }
}
