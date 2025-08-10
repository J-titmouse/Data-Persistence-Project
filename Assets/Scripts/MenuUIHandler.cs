using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;



#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;
    public TMP_Text highname;
    public TMP_Text highscore;
    public TMP_Text Placeholder;
    void Start()
    {
        if (DataManager.Instance.playerName != "")
        {
            Placeholder.color = Color.black;
            Placeholder.fontStyle = FontStyles.Bold; 
            Placeholder.text = DataManager.Instance.playerName;
        }
        string tempText = "";
        for (int i = 0; i < DataManager.Instance.topScoresName.Length; i++)
        {
            tempText = tempText + DataManager.Instance.topScoresName[i] + "\n";
        }
        highname.text = tempText;
        tempText = "";

        for (int i = 0; i < DataManager.Instance.topScores.Length; i++)
        { 
            tempText = tempText + DataManager.Instance.topScores[i] + "\n";
        }
        highscore.text = tempText;
    }
    public void StartNew()
    {
        if (playerName.text != "")
        {
            DataManager.Instance.playerName = playerName.text;
        }
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        DataManager.Instance.SaveToFile();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
