using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject button;
    [SerializeField] GameObject panelPause;
    [SerializeField] GameObject panelTutorial;
    [SerializeField] GameObject buttonClose;
    [SerializeField] GameObject quest;

    private void Start()
    {
        pauseMenu.SetActive(false);
        quest.SetActive(false);
        button.SetActive(true);
        panelTutorial.SetActive(true);
        buttonClose.SetActive(true);
        panelPause.SetActive(false);
    }

    public void PausePanel()
    {
        panelPause.SetActive(true);
    }

    public void PanelTutor()
    {
        panelTutorial.SetActive(true);
        buttonClose.SetActive(true);
        quest.SetActive(true);
    }

    public void Close()
    {
        panelTutorial.SetActive(false);
        buttonClose.SetActive(false);
        isGamePaused = false;
        quest.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        quest.SetActive(true);
        Time.timeScale = 1f; // 1 = aktif; 0 = paused;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
        button.SetActive(false);
        quest.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}