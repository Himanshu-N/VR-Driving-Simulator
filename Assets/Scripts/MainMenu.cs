using UnityEngine.SceneManagement;
using UnityEngine;
using JetBrains.Annotations;

public class MainMenu : MonoBehaviour
{
    public static bool daytrue = true;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DaySelect()
    {
        daytrue = true;
        Debug.Log("Day");
    }
    public void NightSelect()
    {
        Debug.Log("Night");
        daytrue = false;
    }
    public void OnQuitClick()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
