using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public Image pauseButton; // to find the image of our pause button
    public Sprite pausedIcon; // paused image
    public Sprite playIcon; // play image
    public void ResumeGame()
    {
        Time.timeScale = 1; // unpause the game
        pausePanel.SetActive(false);
    }

    public void PauseButton()
    {
        if(pausePanel.activeInHierarchy == true) // if the pause panel is on screen
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseButton.sprite = playIcon;
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            pauseButton.sprite = pausedIcon;
        }
    }
}
