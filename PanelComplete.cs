using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelComplete : MonoBehaviour
{
    public void NextStage()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
