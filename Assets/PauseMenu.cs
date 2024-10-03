using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject traffic;
    [SerializeField] GameObject onToggle;
    [SerializeField] GameObject offToggle;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    public void OnPauseClicked()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
    }

    public void OnResumeClicked()
    {
        pauseMenu.SetActive(false);
        
        Time.timeScale = 1f;
    }

    public void OnMenuClicked(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnQuitClick()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void TrafficOFF()
    {
        traffic.SetActive(true);
        onToggle.SetActive(true);
        offToggle.SetActive(false);

    }
    public void TrafficON()
    {
        traffic.SetActive(false);
        onToggle.SetActive(false);
        offToggle.SetActive(true);
    }
}
