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

    public void StartNew()
    {
        Debug.Log(DataManager.Instance.topScores.Length);
        Debug.Log(DataManager.Instance.topScoresName.Length);
        Debug.Log(playerName.text);
        if (playerName.text != "")
        {
            DataManager.Instance.playerName = playerName.text;
        }
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
