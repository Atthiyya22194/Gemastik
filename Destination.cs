using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Destination : MonoBehaviour
{
    public GameObject player;
    public GameObject PanelComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PanelComplete.SetActive(true);
        }
        //Time.timeScale = 0;
    }
}